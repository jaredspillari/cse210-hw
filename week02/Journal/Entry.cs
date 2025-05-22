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

}


