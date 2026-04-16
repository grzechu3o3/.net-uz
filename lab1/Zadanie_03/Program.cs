Console.WriteLine("Parametry wejsciowe: ");
foreach(string a in args) Console.WriteLine(a);
Console.WriteLine("Zmienna srodowiskowa OS:" + Environment.GetEnvironmentVariable("OS"));
Console.WriteLine("Zmienna srodowiskowa path:" + Environment.GetEnvironmentVariable("path"));