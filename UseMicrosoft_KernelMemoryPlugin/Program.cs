// Copyright (c) Microsoft. All rights reserved.

// source: https://github.com/microsoft/kernel-memory/tree/main/examples/003-dotnet-SemanticKernel-plugin

using Microsoft.Extensions.Configuration;
using Microsoft.KernelMemory;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Plugins.Web;
using Microsoft.SemanticKernel.Plugins.Web.Bing;
using System.ComponentModel;
using System.Linq;
using System.Text;



namespace UseMicrosoft_KernelMemoryPlugin
{
    public partial class Program
    {
        private static string OPENAI_APIKEY;
        private static string KERNEL_MEMORY_APIKEY;

        private static string BING_SEARCH_APIKEY;

        public static async Task Main()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            OPENAI_APIKEY = config["OpenAI:ApiKey"];
            KERNEL_MEMORY_APIKEY = config["KernelMemory:ApiKey"];
            BING_SEARCH_APIKEY = config["BingSearch:ApiKey"];

            // demo: semantic kernel plugin invoke skills
            // - basic: invoke plugin manully in code
            // - basic: invoke plugin manully in prompt template
            // - advanced: invoke plugin in prompt template with custom function ( via LLM inference )

            //await Example01_RAG_Basic_Async();
            //await Example02_RAG_With_Search_Plugins_Async();

            //await Example03_RAG_With_KernelMemory_Plugins_Async();
            //await Example04_RAG_With_KernelMemory_Custom_Plugins_Async();
            //await Example05_DemoFromKernelMemoryOfficalRepo_Async();

            //await Example06_MultiplePluginsDemo_Async();
            await Example07_IngestionWithSynthesis_Async();
            //await Example07_RAGWithSynthesis_Async();
        }
    }
}