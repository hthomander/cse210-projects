using System;

class Program
{
    static void Main()
    {
        string reference = "John 3:16";
        string text = "For Gob so loved the world that He gave His only Son, that whoever believes in Him should not perish but have eternal life.";

        Scripture scripture = new Scripture(reference, text);

        scripture.DisplayScripture();

        while (true)
        {
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input =="quit")
            {
                break;
            }

            scripture.HideRandomWord();
            scripture.DisplayScripture();

            if (scripture.Words.All(w => w.IsHidden))
            {
                Console.WriteLine("All words are hidden. Memorization complete, congrats!");
                break;
            }
        }
    }