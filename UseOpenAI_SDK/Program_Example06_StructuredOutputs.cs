﻿using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UseOpenAI_SDK
{
    internal partial class Program
    {
        static void Example06_StructuredOutputs_JsonSchema()
        {
            // https://platform.openai.com/docs/guides/structured-outputs?lang=curl
            // https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example06_StructuredOutputs.cs

            ChatClient client = new(
                "gpt-4o-mini", 
                OPENAI_APIKEY);

            List<ChatMessage> messages =
            [
                new UserChatMessage("How can I solve 8x + 7 = -23?"),
            ];

            ChatCompletionOptions options = new()
            {
                ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                    jsonSchemaFormatName: "math_reasoning",
                    jsonSchema: BinaryData.FromBytes("""
                    {
                        "type": "object",
                        "properties": {
                        "steps": {
                            "type": "array",
                            "items": {
                            "type": "object",
                            "properties": {
                                "explanation": { "type": "string" },
                                "output": { "type": "string" }
                            },
                            "required": ["explanation", "output"],
                            "additionalProperties": false
                            }
                        },
                        "final_answer": { "type": "string" }
                        },
                        "required": ["steps", "final_answer"],
                        "additionalProperties": false
                    }
                    """u8.ToArray()),
                    jsonSchemaIsStrict: true)
            };

            ChatCompletion completion = client.CompleteChat(messages, options);

            using JsonDocument structuredJson = JsonDocument.Parse(completion.Content[0].Text);

            Console.WriteLine($"Final answer: {structuredJson.RootElement.GetProperty("final_answer")}");
            Console.WriteLine("Reasoning steps:");

            foreach (JsonElement stepElement in structuredJson.RootElement.GetProperty("steps").EnumerateArray())
            {
                Console.WriteLine($"  - Explanation: {stepElement.GetProperty("explanation")}");
                Console.WriteLine($"    Output: {stepElement.GetProperty("output")}");
            }
        }

        static void Example06_StructuredOutputs_JsonObject()
        {
            // https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example06_StructuredOutputs.cs

            ChatClient client = new(
                "gpt-4o-mini",
                OPENAI_APIKEY);

            List<ChatMessage> messages =
            [
                new UserChatMessage("How can I solve 8x + 7 = -23?"),
                new UserChatMessage("response me in this json format: { 'steps': [ { 'explanation': 'reason', 'output': 'result' } ], 'final_answer'': 'answer'' }")
            ];

            ChatCompletionOptions options = new()
            {
                ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat()
            };

            ChatCompletion completion = client.CompleteChat(messages, options);

            using JsonDocument structuredJson = JsonDocument.Parse(completion.Content[0].Text);

            Console.WriteLine($"Final answer: {structuredJson.RootElement.GetProperty("final_answer")}");
            Console.WriteLine("Reasoning steps:");

            foreach (JsonElement stepElement in structuredJson.RootElement.GetProperty("steps").EnumerateArray())
            {
                Console.WriteLine($"  - Explanation: {stepElement.GetProperty("explanation")}");
                Console.WriteLine($"    Output: {stepElement.GetProperty("output")}");
            }
        }


    }
}
