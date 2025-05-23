using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
}