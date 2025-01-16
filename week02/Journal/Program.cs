class Program
{
    static void Main()
    {
        Journal journal =new Journal();
        //my personal prompts
        string[] prompts =
        {
            "What was the most interesting part of your day?",
            "How did you feel when something unexpected happened today?",
            "What do you wish you had done differently today?",
            "What was something you learned today?",
            "Who did you interact with that made your day better?"
        };
        //randomize the prompts, thus fulfilling that portion of project
        Random rand = new Random();

        while (true)
        {
            //show menu options
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                //random prompt
                int promptIndex = rand.Next(prompts.Length);
                Console.WriteLine($"Prompt: {prompts[promptIndex]}");
                //associate response with datetime
                string response = Console.ReadLine();
                DateTime currentDateTime = DateTime.Now;
                Entry entry = new Entry(prompts[promptIndex], response, currentDateTime);
                journal.AddEntry(entry);
                // Ask user if they want to save the entry to a file
                Console.WriteLine("Would you like to save this entry to a file? (y/n)");
                string saveChoice = Console.ReadLine();

                if (saveChoice.ToLower() == "y")
                {
                    Console.WriteLine("Enter filename to save your journal entry:");
                    string filename = Console.ReadLine();
                    journal.SaveJournal(filename);
                    Console.WriteLine($"Journal entry saved successfully to {filename}");
                }

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
                // friendly message when user exits
                case "5":
                Console.WriteLine("Have a great day! See you next time");
                return;
            }
        }
    }
}