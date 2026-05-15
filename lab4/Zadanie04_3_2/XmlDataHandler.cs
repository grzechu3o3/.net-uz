using System.IO;
using System.Xml.Serialization;

public static class XmlDataHandler
{
    public static void SaveData(string filePath, PeopleDatabase db)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PeopleDatabase));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, db);
        }
        Console.WriteLine("Dane zostały pomyślnie zapisane do pliku XML!");
    }

    public static PeopleDatabase LoadData(string filePath)
    {
        if (!File.Exists(filePath)) return new PeopleDatabase();

        XmlSerializer serializer = new XmlSerializer(typeof(PeopleDatabase));
        using (StreamReader reader = new StreamReader(filePath))
        {
            return (PeopleDatabase)serializer.Deserialize(reader);
        }
    }
}