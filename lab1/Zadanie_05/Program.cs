if (args.Length < 2) { Console.Error.WriteLine("Wrong usage, example: progZ4 słowo1 słowo2 <fileIn.txt >fileOut.txt"); }
else
{
    string word1 = args[0];
    string word2 = args[1];

    string line;

    while ((line = Console.In.ReadLine()) != null)
    {
        string modified = line.Replace(word1, word2);

        Console.Out.WriteLine(modified);
    }
}