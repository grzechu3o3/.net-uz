using System.Collections;

public class Zadanie07_Enumerator : IEnumerator<int>
{
    private int[] _data;
    private int _index = -1;

    public Zadanie07_Enumerator(int[] data)
    {
        _data = data;
    }
    public int Current => _data[_index];

    object IEnumerator.Current => Current;

    public void Dispose()
    { 
    }

    public bool MoveNext()
    {
        _index++;
        return _index < _data.Length;
    }

    public void Reset()
    {
        _index = -1;
    }
}
class Zadanie07_Enumerable : IEnumerable<int>
{
    private int[] _data;
    public Zadanie07_Enumerable(int[] data)
    {
        _data = data;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new Zadanie07_Enumerator(_data);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class Program
{
    static void Main()
    {
        var kolekcja = new Zadanie07_Enumerable([1,2,3,6,7]);

        foreach(int liczba in kolekcja)
        {
            Console.WriteLine(liczba);
        }
    }
}