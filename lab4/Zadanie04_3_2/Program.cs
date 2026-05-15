class Program
{
    static void Main()
    {
        string path = "database.xml";

        var db = new PeopleDatabase();
        db.People.Add(new Person { Id = 1, Imie = "Anna", Nazwisko = "Kowalska", Wiek = "32" });
        db.People.Add(new Person { Id = 2, Imie = "Jan", Nazwisko = "Nowak", Wiek = "35" });

        XmlDataHandler.SaveData(path, db);

        var loadedDb = XmlDataHandler.LoadData(path);
        Console.WriteLine("Pomyślnie wczytano dane z pliku XML");
        
        foreach (var p in loadedDb.People)
        {
            Console.WriteLine($"{p.Id}: {p.Imie} {p.Nazwisko} ({p.Wiek})");
        }
    }
}