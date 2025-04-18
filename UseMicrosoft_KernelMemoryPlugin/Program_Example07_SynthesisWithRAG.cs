using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.KernelMemory;
using System.ComponentModel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.Extensions.AI;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace UseMicrosoft_KernelMemoryPlugin
{
    public partial class Program
    {

        #region search
        static async Task Example07_RAGWithSynthesis_Async()
        {
            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    //modelId: "gpt-4o-mini",
                    //modelId: "o1",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(true));

            var kernel = builder.Build();

            kernel.ImportPluginFromType<CustomSynthesisSearchPlugin>("andrew_blog_search");


            var settings = new OpenAIPromptExecutionSettings
            {
                Temperature = 0,
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };


            // 根據不同的問法，Plugin 有能力調整不同的檢索條件, 挑出最適當的內容來進行 RAG
            string question =
                //"摘要安德魯寫過的 RAG 主題，它的核心概念是甚麼?";     // 意圖: Abstract
                "安德魯說明過那些跟 WSL 相關的解題案例?";            // 意圖: Problem
                //"安德魯說明過那些跟 WSL 相關的常見問題?";             // 意圖: Question
                //"我想知道安德魯寫過那些關於 WSL 的內容，我要看他的原文片段，請勿摘要或是彙整, 謝謝!"; // 意圖: None

            /*



             */
            Console.WriteLine(await kernel.InvokePromptAsync<string>(
                """
                <message role="system">
                你的任務是協助使用者找尋相關的資訊，並且依據 Search Result: Facts 為基礎，回覆使用者提出的 Question。
                若你無法回答請直接回答 "我不知道!"。

                回覆問題時，請在最後面附上你參考的資料來源，要包含內容與網址。
                附註的格式如下:
                --
                # 參考資料
                - (1), [參考標題](參考網址): 參考內容
                - (2), [參考標題](參考網址): 參考內容
                </message>
                <message role="user">
                # Question
                {{$question}}
                </message>
                """ +
                //"""
                //<message role="user">
                //# Facts
                //{{andrew_blog_search.search query=$question limit="5" synthesis="none"}}
                //{{andrew_blog_search.search query=$question limit="5" synthesis="abstract"}}
                //{{andrew_blog_search.search query=$question limit="5" synthesis="question"}}
                //{{andrew_blog_search.search query=$question limit="5" synthesis="problem"}}
                //</message>
                //""" +
                """
                <message role="user">
                # Answer
                </message>
                """,
                new(settings)
                {
                    ["question"] = question
                }));
        }

        public class CustomSynthesisSearchPlugin
        {
            public enum SynthesisTypeEnum
            {
                [Description("內容合成: Abstract, 摘要資訊")]
                Abstract,
                [Description("內容合成: Question, 將敘述內容摘要成問答形式 (FAQ), 有利於針對問題(Question)或是答案的精準檢索要求")]
                Question,
                [Description("內容合成: Problem Solving, 將敘述內容摘要成問題解決的形式，歸納成問題(Problem),原因(RootCause),解決方案(Resolution),案例(Example)的形式，有利於針對問題(Problem)的檢索，或是針對特定解決方案(Resolution)的檢索要求。")]
                Problem,
                [Description("內容合成: None, 沒有經過合成處理，直接檢索原始內容時適用")]
                None,
            }

            [KernelFunction("search")]
            [Description("Search Andrew's blog for the given query. Andrew is Microsoft MVP, good in .NET and AI application development.")]
            static async Task<string> AndrewBlogSearchResultAsync(
                [Description("The query to search for.")] string query,
                [Description("Search from which synthesis source? abstract | question | problem | none")]SynthesisTypeEnum synthesis,
                [Description("The index to search in.")] int limit)
            {
                var km = new MemoryWebClient("http://127.0.0.1:9001/", KERNEL_MEMORY_APIKEY);
                var result = await km.SearchAsync(
                    query, 
                    index: "blog",
                    filter: (new MemoryFilter()).ByTag("synthesis", synthesis.ToString().ToLower()),
                    //filter: (new MemoryFilter()).ByTag("synthesis", "none"),
                    limit: limit);

                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Results)
                {
                    foreach (var p in item.Partitions)
                    {
                        sb.AppendLine("".PadRight(80, '='));
                        sb.AppendLine($"## Fact:");
                        sb.AppendLine();
                        sb.AppendLine($" - Relevance: {p.Relevance}%");
                        sb.AppendLine($" - Title:     {p.Tags["post-title"][0]}");
                        sb.AppendLine($" - URL:       {p.Tags["post-url"][0]}");

                        switch (synthesis)
                        {
                            case SynthesisTypeEnum.Abstract:
                                sb.AppendLine($" - Format:    Abstract");
                                break;
                            case SynthesisTypeEnum.Question:
                                sb.AppendLine($" - Format:    FAQ");
                                break;
                            case SynthesisTypeEnum.Problem:
                                sb.AppendLine($" - Format:    Problem Solving");
                                break;
                            case SynthesisTypeEnum.None:
                            default:
                                sb.AppendLine($" - Format:    Original Content");
                                break;
                        }

                        sb.AppendLine();
                        sb.AppendLine($"```");
                        sb.AppendLine(p.Text);
                        sb.AppendLine($"```");
                        sb.AppendLine();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Kernel Memory Search Results:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(sb.ToString());
                Console.ResetColor();

                return sb.ToString();
            }
        }
        #endregion

        #region ingest
        static async Task Example07_IngestionWithSynthesis_Async()
        {
            //
            var builder = Kernel.CreateBuilder();
            builder
                .AddOpenAIChatCompletion(
                    //modelId: "gpt-4o",
                    //modelId: "o1",
                    modelId: "o3",
                    apiKey: OPENAI_APIKEY,
                    httpClient: HttpLogger.GetHttpClient(false));

            var kernel = builder.Build();
            var chat = kernel.GetRequiredService<IChatCompletionService>();

            const string base_folder = //@"D:\CodeWork\github.com\AndrewDemo.DevAIAPPs\UseMicrosoft_KernelMemoryPlugin\blogs\";
                @"..\..\..\blogs\";

            string post_folder = Path.Combine(base_folder, "posts");
            string synthesis_folder = Path.Combine(base_folder, "synthesis");

            var memory = new MemoryWebClient("http://localhost:9001/", KERNEL_MEMORY_APIKEY);

            foreach(string file in Directory.GetFiles(post_folder))
            {
                var filename = Path.GetFileNameWithoutExtension(file);

                var history = new ChatHistory(
                    """
                    你是部落格的編輯助手，我需要你按照下列要求，幫我處理我寫好的文章 (長文章，通常約有 50 ~ 100kb 的字數):

                    Step 1. 擷取文章的 metadata, 用下列的 json format 回傳給我
                    {
                      "title": { post titme },
                      "publish-date": { post publish date },
                      "categories": [ { category } ],
                      "tags": [ { tag } ],
                      "url": null,
                      "software": [ {列出文內所有使用到的軟體或開發工具清單} ],
                      "reference": [ {列出文內所有參考資料或引用的文章清單} ]
                    }

                    Step 2. 全文層級摘要, 500 字, 用下列 markdown 結構:
                    ## Abstraction
                    { 摘要 }

                    Step 3. 段落層級摘要, 每段 500 字
                    ## 段落{n}, { 段落標題 }
                    { 摘要內容 }

                    Step 4. 用 FAQ 型態歸納文章的摘要，沒有數量上限。每組問答的內容，控制在 500 字以內
                    ## FAQ
                    Q{n}: {問題}
                    A{n}: {回答}

                    Step 5. 用解決問題 Case 的型態來歸納文章的摘要。找出文章內提了那些問題 (Problem)，並且有說明原因 (RootCause)，解法 (Resolution)，案例 (Example) 的結構，沒有上限，條列給我。
                    ## Problem Solving
                    Case {n}: {標題}
                    - Problem: {問題敘述}
                    - RootCause: {原因分析}
                    - Resolution: {解決方案}
                    - Analysis: {分析說明, 用 3x5 why 的原則來分析, 給我分析表格, 無法追溯的上層原因, 就留空白。表格欄位放 3 面向, 5行 放五層上層原因}
                    - Example: {案例說明}


                    --
                    以上是任務需求, 後續我上傳文章內容後，就可以開始回覆
                    一次回覆一個 Step 給我，總共五個 Step(s)
                    每個主題請個別按照我要求的格式輸出，不用作內容回覆以外額外的任何說明
                    """);

                history.AddUserMessage(
                    "以下是文章內容\n--\n" +
                    File.ReadAllText(file));


                var postinfo_part = await CacheIfAsync(
                    Path.Combine(synthesis_folder, $"{filename}-postinfo.json"),
                    async () =>
                {
                    var result = await chat.GetChatMessageContentsAsync(
                        history,
                        new OpenAIPromptExecutionSettings()
                        {
                            ResponseFormat = typeof(PostInfo)
                        });
                    return result[0].Content;
                });



                var postinfo = JsonSerializer.Deserialize<PostInfo>(postinfo_part);
                postinfo.Url = _parse_filename_to_url(file);

                history.AddAssistantMessage(postinfo_part);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("JSON:");
                Console.ResetColor();
                Console.WriteLine(JsonSerializer.Serialize<PostInfo>(postinfo, new JsonSerializerOptions() { WriteIndented = true }));







                history.AddUserMessage("繼續 Step 2. 全文層級摘要");

                var abstract_part = await CacheIfAsync(
                    Path.Combine(synthesis_folder, $"{filename}-abstract.md"),
                    async () =>
                {
                    var result = await chat.GetChatMessageContentsAsync(history);
                    return string.Join("\n", result.Select(r => r.Content));
                });



                history.AddAssistantMessage(abstract_part);


                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("LV1 Abstract:");
                Console.ResetColor();
                Console.WriteLine(abstract_part);





                history.AddUserMessage("繼續 Step 3. 段落層級摘要");

                var paragraph_part = await CacheIfAsync(
                    Path.Combine(synthesis_folder, $"{filename}-paragraph.md"),
                    async () =>
                {
                    var result = await chat.GetChatMessageContentsAsync(history);
                    return string.Join("\n", result.Select(r => r.Content));
                });


                history.AddAssistantMessage(paragraph_part);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("LV2 Abstract:");
                Console.ResetColor();
                Console.WriteLine(paragraph_part);




                history.AddUserMessage("繼續 Step 4. 用 FAQ 型態歸納文章的摘要");

                var question_part = await CacheIfAsync(
                    Path.Combine(synthesis_folder, $"{filename}-question.md"),
                    async () =>
                    {
                        var result = await chat.GetChatMessageContentsAsync(history);
                        return string.Join("\n", result.Select(r => r.Content));
                    });


                history.AddAssistantMessage(question_part);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("FAQ:");
                Console.ResetColor();
                Console.WriteLine(question_part);





                history.AddUserMessage("繼續 Step 5. 用解決問題 Case 的型態來歸納文章的摘要");
                var problem_part = await CacheIfAsync(
                    Path.Combine(synthesis_folder, $"{filename}-problem.md"),
                    async () =>
                {
                    var result = await chat.GetChatMessageContentsAsync(history);
                    return string.Join("\n", result.Select(r => r.Content));
                });


                history.AddAssistantMessage(problem_part);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Problem Solving:");
                Console.ResetColor();
                Console.WriteLine(problem_part);



                // prepare tags
                var docid = Path.GetFileNameWithoutExtension(file).ToLower();
                var tags = new TagCollection()
                {
                    ["post-title"] = [ postinfo.Title ],
                    ["post-date"] = [postinfo.PublishDate],
                    ["post-url"] = [postinfo.Url],
                    ["categories"] = postinfo.Categories.ToList(),
                    ["user-tags"] = postinfo.Tags.ToList(),

                    ["software"] = postinfo.Software.ToList(),
                    ["reference"] = postinfo.Reference.ToList()
                };


                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Uploading... ");

                // upload article
                Console.Write("#");
                tags["synthesis"] = new List<string>() { "none" };
                await memory.ImportDocumentAsync(
                    file,
                    documentId: $"{docid}",
                    tags:  tags,
                    index: "blog");

                // upload synthesis content
                Console.Write("#");
                tags["synthesis"] = new List<string>() { "abstract" };
                await memory.ImportDocumentAsync(
                    new Document(
                        id: $"{docid}-abstract",
                        tags: tags,
                        filePaths: new[]
                        {
                            Path.Combine(synthesis_folder, $"{filename}-abstract.md"),
                            Path.Combine(synthesis_folder, $"{filename}-paragraph.md")
                        }),
                    index: "blog");


                Console.Write("#");
                tags["synthesis"] = new List<string>() { "question" };
                await memory.ImportDocumentAsync(
                    Path.Combine(synthesis_folder, $"{filename}-question.md"),
                    documentId: $"{docid}-question",
                    tags: tags,
                    index: "blog");

                Console.Write("#");
                tags["synthesis"] = new List<string>() { "problem" };
                await memory.ImportDocumentAsync(
                    Path.Combine(synthesis_folder, $"{filename}-problem.md"),
                    documentId: $"{docid}-problem",
                    tags: tags,
                    index: "blog");

                Console.WriteLine("Done.");
                Console.ResetColor();
            }
        }


        static string _parse_filename_to_url(string filename)
        {
            //string fileName = "2024-11-11-working-with-wsl.md";
            string pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})-(?<name>.+)\.md";

            Match match = Regex.Match(filename, pattern);

            if (match.Success)
            {
                string year = match.Groups["year"].Value;
                string month = match.Groups["month"].Value;
                string day = match.Groups["day"].Value;
                string name = match.Groups["name"].Value;

                return $"https://columns.chicken-house.net/{year}/{month}/{day}/{name}";
            }

            return null;
        }

        static async Task<string> CacheIfAsync(string filePath, Func<Task<string>> generateContent, bool ignore_cache = false)
        {
            if (ignore_cache || !File.Exists(filePath))
            {
                var content = await generateContent();
                await File.WriteAllTextAsync(filePath, content);
                return content;
            }
            else
            {
                return await File.ReadAllTextAsync(filePath);
            }
        }


        public class PostInfo
        {
            public string Title { get; set; }
            public string PublishDate { get; set; }
            public string[] Categories { get; set; }
            public string[] Tags { get; set; }
            public string Url { get; set; }


            public string[] Software { get; set; }
            public string[] Reference { get; set; }
        }
        #endregion
    }
}
