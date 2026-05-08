using System.Collections.Generic;
using System.Xml.Serialization;

public class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public int Wiek { get; set; }
}

[XmlRoot("ArrayOfOsoba")]
public class ListaOsob
{
    [XmlElement("Osoba")]
    public List<Osoba> Osoby { get; set; }
}