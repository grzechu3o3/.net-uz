using System;
using System.ServiceModel;
using Zadanie04_1_3;

namespace Zadanie04_1_3_klient
{
  
    [ServiceContract]
    public interface IUsluga3
    {
        [OperationContract]
        string WykonajZadanie(int param1, int param2);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Naciśnij ENTER, aby połączyć się z Usługą Windows...");
            Console.ReadLine();

            string address = "net.pipe://localhost/Usluga3";

            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            ChannelFactory<IZadanie> factory = new ChannelFactory<IZadanie>(binding, new EndpointAddress(address));

            try
            {
                IZadanie proxy = factory.CreateChannel();

                Console.WriteLine("Wysyłam zadanie do usługi w tle...");

                string odpowiedz = proxy.doTask(6,7);

                Console.WriteLine();
                Console.WriteLine("=== OTRZYMANO ODPOWIEDŹ ===");
                Console.WriteLine(odpowiedz);
            }
            catch (EndpointNotFoundException)
            {
                Console.WriteLine("BŁĄD: Nie znaleziono punktu końcowego. Czy usługa na pewno jest URUCHOMIONA w services.msc?");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
            finally
            {
                if (factory.State == CommunicationState.Opened)
                {
                    factory.Close();
                }
            }

            Console.WriteLine("\nNaciśnij ENTER, aby zakończyć.");
            Console.ReadLine();
        }
    }
}