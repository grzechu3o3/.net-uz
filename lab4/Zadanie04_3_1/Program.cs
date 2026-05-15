using System.Xml.Serialization;
using Zadanie04_3_1;

public class Program
{
    public static void Main()
    {
        var osoba1 = new Osoba
        {
            Imie = "Jan",
            Nazwisko = "Kowalski",
            Wiek = 25
        };
        
        XmlSerializer serializer = new XmlSerializer(typeof(Osoba));

        using (StreamWriter writer = new StreamWriter("osoba.xml"))
        {
            serializer.Serialize(writer, osoba1);
            writer.Close();
        }
        
        Console.WriteLine("Osoba zapisana do pliku XML");


        List<Osoba> osoby = new List<Osoba>
        {
            new Osoba() { Imie = "Jan", Nazwisko = "Kowalski", Wiek = 24 },
            new Osoba() { Imie = "Janusz", Nazwisko = "Gomułka", Wiek = 19 }
        };
        
        XmlSerializer serializer2 = new XmlSerializer(typeof(List<Osoba>));
        using (StreamWriter writer = new StreamWriter("osoby.xml"))
        {
            serializer2.Serialize(writer, osoby);
            writer.Close();
        }
        
        Console.WriteLine("Lista osob zapisana do pliku XML");
    }
}