class Program
{
    static void Main()
    {
        Journal journal =new Journal();
        string[] prompts =
        {
            "What was the most interesting part of your day?",
            "How did you feel when something unexpected happened today?",
            "What do you wish you had done differently today?",
            "What was something you learned today?",
            "Who did you interact with that made your day better?"
        };
        Random rand = new Random();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save jouranl to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                int promptIndex = rand.Next(prompts.Length);
                Console.WriteLine($"Prompt: {prompts[promptIndex]}");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                Entry entry = new Entry(prompts[promptIndex], response, date);
                journal.AddEntry(entry);
                break;

                case "2":
                journal.DisplayEntries();
                break;

                case "3": 
                Console.WriteLine("Enter filename to save journal:");
                string saveFilename = Console.ReadLine();
                journal.SaveJournal(saveFilename);
                break;

                case "4":
                Console.WriteLine("Enter filename to load journal:");
                string loadFilename = Console.ReadLine();
                journal.LoadJournal(loadFilename);
                break;

                case "5":
                Console.WriteLine("Have a great day! See you next time")
                return;
            }
        }
    }
}