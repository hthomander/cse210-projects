using System;
using System.Collections.Generic;
using System.IO;

public record Journal
{
    private List<Entry> _entries = new List<Entry>();

    //add a new entry to journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    //display all journal entries
    public void DisplayEntries()
    {
        //account for no entries saved
        if (_entries.Count == 0)
        {
            //error message 
            Console.WriteLine("No entries in the journal yet.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.DateTime}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            //formatting with a line break
            Console.WriteLine($"---------------------------------------------------");
        }
    }

    //save journal
    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.DateTime}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    //load the journal from a file
    public void LoadJournal(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        DateTime entryDate = DateTime.ParseExact(parts[0], "yyyy-MM-dd HH:mm:ss", null);
                        _entries.Add(new Entry(parts[1], parts [2], entryDate));
                    }
                }
            }
        }

        else
        {
            //error message
            Console.WriteLine("File not found!");
        }
    }
}
