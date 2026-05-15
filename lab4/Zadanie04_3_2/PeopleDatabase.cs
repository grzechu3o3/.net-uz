using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Database")]
public class PeopleDatabase
{
    [XmlElement("Osoba")]
    public List<Person> People { get; set; } = new List<Person>();
}

public class Person
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Wiek { get; set; }
}