if (args.Length == 0)
{
    foreach (string file in Directory.GetFiles("."))
    {
        Console.WriteLine(file);
    }
    foreach (string directory in Directory.GetDirectories(".")) Console.WriteLine("[DIR] " + directory);
}
else
{
    if (Directory.Exists(args[0]))
    {
        foreach (string file in Directory.GetFiles(args[0]))
        {
            Console.WriteLine("[FILE] " + file);
        }
        foreach (string directory in Directory.GetDirectories(args[0])) Console.WriteLine("[DIR] " + directory);
    }
}