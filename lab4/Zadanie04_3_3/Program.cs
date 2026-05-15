using System;
using System.Xml;
using System.Xml.Schema;

class XmlValidator
{
    static void Main()
    {
        string xmlPath = "database.xml";
        string xsdPath = "schemat.xsd";

        ValidateXmlWithXsd(xmlPath, xsdPath);
    }

    static void ValidateXmlWithXsd(string xmlPath, string xsdPath)
    {
        try
        {
            XmlReaderSettings settings = new XmlReaderSettings();

            settings.Schemas.Add(null, xsdPath);
            settings.ValidationType = ValidationType.Schema;

            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            settings.ValidationEventHandler += (sender, args) =>
            {
                Console.WriteLine($"[{args.Severity}] Błąd: {args.Message}");
            };

            using (XmlReader reader = XmlReader.Create(xmlPath, settings))
            {
                while (reader.Read()) { }
            }

            Console.WriteLine("Walidacja XSD zakończona pomyślnie (jeśli nie wyświetlono błędów powyżej).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd krytyczny: {ex.Message}");
        }
    }
}