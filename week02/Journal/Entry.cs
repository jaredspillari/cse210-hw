using System;

public class Entry
{
    public string _Date;
    public string _Prompt;
    public string _Response;

    public void Display()
    {
        Console.WriteLine($"Date:{_Date}");
        Console.WriteLine($"Question:{_Prompt}");
        Console.WriteLine($"Answer:{_Response}");
    }
    public string GetFormattedEntry()
    {
        return $"{_Date}|{_Prompt}|{_Response}";
    }
    public static Entry FromFormattedEntry(string line)
    {
        string[] parts = line.Split('|');
        return new Entry
        {
            _Date = parts[0],
            _Prompt = parts[1],
            _Response = parts[2]
        };
    }

}


