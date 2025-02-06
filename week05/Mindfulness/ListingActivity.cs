using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    public void StartListingActivity()
    {
        StartActivity();

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);

        Console.WriteLine("You have 5 seconds to think...");
        Pause(5);

        int count = 0;
        string input;
        while (_duration > 0)
        {
            Console.WriteLine("Enter an item: ");
            input = Console.ReadLine();
            count++;
            _duration--;
        }

        Console.WriteLine($"You listed {count} items.");
        EndActivity();
    }
}