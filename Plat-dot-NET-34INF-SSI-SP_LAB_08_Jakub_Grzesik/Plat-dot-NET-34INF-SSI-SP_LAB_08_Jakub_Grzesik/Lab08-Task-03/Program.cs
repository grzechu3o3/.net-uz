#pragma warning disable SKEXP0070

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using System.ComponentModel;
using System.Threading.Tasks;



namespace Lab08_Task_03
{

    public class MyTimePlugin
    {
        [KernelFunction, Description("Get the current time")]
        public DateTimeOffset Time() => DateTimeOffset.Now;
    }

    [Description("Represents a light bulb")]
    public class MyLightPlugin(bool turnedOn = false)
    {
        private bool _turnedOn = turnedOn;

        [KernelFunction, Description("Returns whether this light is on")]
        public bool IsTurnedOn() => _turnedOn;

        [KernelFunction, Description("Turn on this light")]
        public void TurnOn() => _turnedOn = true;

        [KernelFunction, Description("Turn off this light")]
        public void TurnOff() => _turnedOn = false;
    }

    public class MyAlarmPlugin
    {
        private string _hour;

        public MyAlarmPlugin(string providedHour)
        {
            this._hour = providedHour;
        }

        [KernelFunction, Description("Sets an alarm at the provided time")]
        public string SetAlarm(string time)
        {
            this._hour = time;
            return GetCurrentAlarm();
        }

        [KernelFunction, Description("Get current alarm set")]
        public string GetCurrentAlarm()
        {
            return $"Alarm set for {_hour}";
        }
    }

    internal class Program
    {

        public static async Task ExamplePromptWithCodeMoreAdv()
        {
            var builder = Kernel.CreateBuilder();
            var modelId = "llama3.2";
            var endpoint = new Uri("http://localhost:11434");

            builder.Services.AddOllamaChatCompletion(modelId, endpoint);

            builder.Plugins
                .AddFromType<MyTimePlugin>()
                .AddFromObject(new MyLightPlugin(turnedOn: true))
                .AddFromObject(new MyAlarmPlugin("11"));

            var kernel = builder.Build();
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            var settings = new OllamaPromptExecutionSettings { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };

            Console.WriteLine("""
    Ask questions or give instructions to the copilot such as:
    - Change the alarm to 8
    - What is the current alarm set?
    - Is the light on?
    - Turn the light off please.
    - Set an alarm for 6:00 am.
    """);

            Console.Write("> ");

            string? input = null;
            while ((input = Console.ReadLine()) is not null)
            {
                Console.WriteLine();

                try
                {
                    ChatMessageContent chatResult = await chatCompletionService.GetChatMessageContentAsync(input, settings, kernel);
                    Console.Write($"\n>>> Result: {chatResult}\n\n> ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\n\n> ");
                }
            }


        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Lab08-Task-03");

            await ExamplePromptWithCodeMoreAdv();
        }
    }
}
