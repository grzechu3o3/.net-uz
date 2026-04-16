
using System.Runtime.InteropServices.ObjectiveC;

class Program
{
    static int globalMax = int.MinValue;
    static object lockObj = new Object();

    static void Main()
    {
        int[] dane = Generuj(10_000_000);

        int liczbaWatkow = 8;
        Thread[] watki = new Thread[liczbaWatkow];

        int chunkSize = dane.Length / liczbaWatkow;

        for(int i = 0; i < liczbaWatkow; i++)
        {
            int start = i * chunkSize;
            int end = (i == liczbaWatkow - 1) ? dane.Length : start + chunkSize;

            watki[i] = new Thread(() => SzukajMax(dane, start, end));
            watki[i].Start();
        }
        foreach (var w in watki) w.Join();

        Console.WriteLine($"Max = {globalMax}");
    }

    static void SzukajMax(int[] dane, int start, int end)
    {
        int localMax = int.MinValue;
        
        for(int i = start; i<end; i++)
        {
            if (dane[i] > localMax) localMax = dane[i];
        }
        lock (lockObj)
        {
            if (localMax > globalMax) globalMax = localMax;
        }
    }
    
    static int[] Generuj(int size)
    {
        Random rand = new Random();
        int[] dane = new int[size];
        for(int i=0;i<size;i++)
        {
            dane[i] = rand.Next();
        }

        return dane;
    }
}