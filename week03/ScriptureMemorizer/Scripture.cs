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

    public void HideRandomWordInIncrements()
        {
            var visibleWords = Words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count > 3)
            {
                Random rand = new Random();
                var wordsToHide = visibleWords.OrderBy(w => rand.Next()).Take(3).ToList();
                foreach (var word in wordsToHide)
                {
                    word.IsHidden = true;
                    
                }
            }
            else if (visibleWords.Count > 0)
            {
                foreach ( var word in visibleWords)
                {
                    word.IsHidden = true;
                }
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