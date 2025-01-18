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
                string formattedDate = entry.DateTime.ToString("yyyy-MM-dd HH:mm:ss"); //ISO-like format
                writer.WriteLine($"{formattedDate} | {entry.Prompt} | {entry.Response}");
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
                        //trim any leading or trailing spaces
                        string dateString = parts[0].Trim();
                        string prompt = parts[1].Trim();
                        string response = parts [2].Trim();

                        //debuggin output for parts
                        Console.WriteLine($"Reading line: '{line}'");
                        Console.WriteLine($"Parsed date: '{dateString}', Prompt: '{prompt}', Response: '{response}'");


                        DateTime entryDate; 
                        if (DateTime.TryParseExact(dateString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out entryDate))
                        {
                            _entries.Add(new Entry(prompt, response, entryDate));
                        }
                        else 
                        {
                            Console.WriteLine($"Invalid date format in entry: {dateString}");
                        }
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
