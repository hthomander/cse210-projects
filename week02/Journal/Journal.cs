using System;
using System.collections.Generic;
using System.IO;

public record Journal(List<Entry> Entries)
{
    public Journal() : this(new List<Entry>())
    {
    }

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt}\n{entry.Response}\n");
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        if (File.Exists(filename))
        {
            Entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    var entry = new Entry(parts[1], parts[2], parts[0]);
                    Entries.Add(entry);
                }
            }
        }

        else
        {
            Console.WriteLine("""File not found!""")
        }
    }
}

using System;