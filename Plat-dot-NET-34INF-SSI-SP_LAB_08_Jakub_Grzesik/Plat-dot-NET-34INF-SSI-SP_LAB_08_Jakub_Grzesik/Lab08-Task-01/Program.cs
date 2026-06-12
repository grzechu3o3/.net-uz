#pragma warning disable SKEXP0070

using Microsoft.SemanticKernel;

namespace Lab08_Task_01
{
    internal class Program
    {

        public static async Task ExamplePrompt()
        {
            //Kernel kernel = Kernel.CreateBuilder().AddOllamaChatCompletion("llama3.1:8b", new Uri(uriString: "http://localhost:11434")).Build();
            Kernel kernel = Kernel.CreateBuilder().AddOllamaChatCompletion("llama3.2", new Uri(uriString: "http://localhost:11434")).Build();
            

            Console.WriteLine("First prompt as async without streaming");
            Console.WriteLine(await kernel.InvokePromptAsync("What color is the sky?"));
            Console.WriteLine();

            Console.WriteLine("Streaming prompts");
            Console.WriteLine();
            KernelArguments arguments = new() { { "topic", "sea" } };
            await foreach (var update in kernel.InvokePromptStreamingAsync("What color is the {{$topic}}? Provide a detailed explanation.", arguments))
            {
                Console.Write(update);
            }
            Console.WriteLine();

            Console.WriteLine("Press Enter to end program.");
            Console.ReadLine();
        }

        static async Task Main(string[] args)
        {
            // ollama model downloading
            // ollama pull llama3.1:8b
            // --> or smaller model
            // ollama pull llama3.2 

            // package installation from VS NuGet console:
            // NuGet\Install-Package Microsoft.SemanticKernel.Connectors.Ollama -Version 1.55.0-alpha

            Console.WriteLine("Lab08-Task-01");

            await ExamplePrompt();

        }
    }
}
