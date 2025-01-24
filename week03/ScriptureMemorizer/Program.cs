using System;

class Program
{
    static void Main()
    {
        string reference = "John 3:16";
        string text = "For God so loved the world that He gave His only Son, that whoever believes in Him should not perish but have eternal life.";

       while (true)
       {
        Scripture scripture = new Scripture(reference, text);

        scripture.DisplayScripture();


        while (true)
        {
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input =="quit")
            {
                Console.WriteLine("Thanks for trying! Try more later!!");
                return;
            }

            scripture.HideRandomWordInIncrements();
            scripture.DisplayScripture();

            if (scripture.Words.All(w => w.IsHidden))
            {
                Console.WriteLine("All words are hidden. Memorization complete, congrats!");
                break;
            }
        }

        Console.WriteLine("Would you like to try again? (yes/no)");
        string restartInput = Console.ReadLine().Trim().ToLower();

        if (restartInput !="yes")
        {
            Console.WriteLine("Thanks for practicing!");
            break;
        }
    }
}

}
    