using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; set;}
    public List<Word> Words { get; set; }

    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        Words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWord()
        {
            var visibleWords = Words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count > 0)
            {
                Random rand = new Random();
                var wordToHide = visibleWords[rand.Next(visibleWords.Count)];
                wordToHide.IsHidden = true;
            }
        }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(Reference.Text);
        foreach (var word in Words)
        {
            Console.Write(word.GetDisplayText() + " " );
        }
        Console.WriteLine();
    }

}