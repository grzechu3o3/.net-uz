#pragma warning disable SKEXP0070

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using System.ComponentModel;



namespace Lab08_Task_04
{
    internal class Program
    {
        internal sealed class BookingsPlugin
        {
            private readonly string _businessId;
            private readonly string _customerTimeZone;
            private readonly string _serviceId;

            internal BookingsPlugin(
                string businessId,
                string serviceId,
                string customerTimeZone = "Poland/Warsaw"
            )
            {
                this._businessId = businessId;
                this._serviceId = serviceId;
                this._customerTimeZone = customerTimeZone;
            }

            [KernelFunction("BookTable")]
            [Description("Books a new table at a restaurant")]
            public async Task<string> BookTableAsync(
                [Description("Name of the restaurant")] string restaurant,
                [Description("The time in UTC")] DateTime dateTime,
                [Description("Number of people in your party")] int partySize,
                [Description("Customer name")] string customerName,
                [Description("Customer email")] string customerEmail,
                [Description("Customer phone number")] string customerPhone
            )
            {
                Console.WriteLine($"System > Do you want to book a table at {restaurant} on {dateTime} for {partySize} people?");
                Console.WriteLine("System > Please confirm by typing 'yes' or 'no'.");
                Console.Write("User > ");
                var response = Console.ReadLine()?.Trim();
                if (string.Equals(response, "yes", StringComparison.OrdinalIgnoreCase))
                {

                    Console.WriteLine("begin booking");
                    Console.WriteLine($"\tbook: {restaurant} on {dateTime} for {partySize} people");
                    Console.WriteLine($"\tbook: {customerName} email: {customerEmail} phone {customerEmail}");
                    Console.WriteLine("end booking (FALSE, operation on DB is not performed!)");

                    return "Booking successful!";
                }

                return "Booking aborted by the user";
            }

            [KernelFunction]
            [Description("List reservations booking at a restaurant.")]
            public async Task<List<Appointment>> ListReservationsAsync()
            {
                // Print the booking details to the console
                var resultList = new List<Appointment>();

                Console.WriteLine("begin List reservations");
                //foreach (var appointmentResponse in appointments?.Value!)
                //{
                //    resultList.Add(new Appointment(appointmentResponse));
                //}
                Console.WriteLine("end booking (FALSE, operation on DB is not performed!)");

                return resultList;
            }

            [KernelFunction]
            [Description("Cancels a reservation at a restaurant.")]
            public async Task<string> CancelReservationAsync(
                [Description("The appointment ID to cancel")] string appointmentId,
                [Description("Name of the restaurant")] string restaurant,
                [Description("The date of the reservation")] string date,
                [Description("The time of the reservation")] string time,
                [Description("Number of people in your party")] int partySize)
            {
                // Print the booking details to the console
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"System > [Cancelling a reservation for {partySize} at {restaurant} on {date} at {time}]");
                Console.ResetColor();
                
                Console.WriteLine("booking cancelled! (FALSE, operation on DB is not performed!)");
                

                return "Cancellation successful!";
            }
        }
        internal sealed class Appointment
        {
            internal Appointment(DateTime Start_DateTime, string Restaurant_Name, int Party_Size, string ID)
            {
                this.Start = Start_DateTime;
                this.Restaurant = Restaurant_Name;
                this.PartySize = Party_Size;
                this.ReservationId = ID;
            }

            /// <summary>
            /// Start date and time of the appointment.
            /// </summary>
            public DateTime Start { get; set; }

            /// <summary>
            /// The restaurant name.
            /// </summary>
            public string? Restaurant { get; set; }

            /// <summary>
            /// Number of people in the party.
            /// </summary>
            public int PartySize { get; set; }

            /// <summary>
            /// The reservation id.
            /// </summary>
            public string? ReservationId { get; set; }
        }

        public static async Task ExampleAssistant()
        {
            var builder = Kernel.CreateBuilder();
            var modelId = "llama3.2";
            var endpoint = new Uri("http://localhost:11434");

            builder.Plugins.AddFromObject(new BookingsPlugin("MyBusinessId001", "MyServiceID001"));

            builder.Services.AddOllamaChatCompletion(modelId, endpoint);

            var kernel = builder.Build();
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            ChatHistory chatHistory = [];
            string? input = null;

            while (true)
            {
                Console.Write("User > ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    // Leaves if the user hit enter without typing any word
                    break;
                }

                // Add the message from the user to the chat history
                chatHistory.AddUserMessage(input);

                // Enable auto function calling
                var executionSettings = new OllamaPromptExecutionSettings {
                    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                };

                // Get the result from the AI
                var result = await chatCompletionService.GetChatMessageContentAsync(chatHistory, executionSettings, kernel);

                // Print the result
                Console.WriteLine("Assistant > " + result);

                // Add the message from the agent to the chat history
                chatHistory.AddMessage(result.Role, result?.Content!);
            }


        }
        static async Task Main(string[] args)
        {

            // example of prompts:

            // I would like to book a table at the restaurant "The UZ Exam" on the 20th of June at 10:00 AM for 43 people. My name is John Doe, my email address is john @internet.com, and my phone number is 123 - 999 - 7890.

            // List my current bookings

            // Cancel my booking at "The French Laundy" on 15th of May at 7:00PM for 7 people.

            Console.WriteLine("Lab08-Task-04");

            await ExampleAssistant();

        }
    }
}
