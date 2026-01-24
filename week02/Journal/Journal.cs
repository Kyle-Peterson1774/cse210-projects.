using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet. Your journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Total entries: {_entries.Count}");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Nothing loaded.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                _entries.Add(Entry.FromFileString(line));
            }
        }
    }


    public void Search(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Search keyword was empty.");
            return;
        }

        string k = keyword.Trim().ToLower();
        int matches = 0;

        foreach (Entry entry in _entries)
        {
            bool hit =
                (entry.Prompt ?? "").ToLower().Contains(k) ||
                (entry.Response ?? "").ToLower().Contains(k) ||
                (entry.Tags ?? "").ToLower().Contains(k);

            if (hit)
            {
                entry.Display();
                matches++;
            }
        }

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Matches found: {matches}");
    }
}
