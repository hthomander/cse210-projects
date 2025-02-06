using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heros?"
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

        Console.WriteLine($"Start listing your items. You have {_duration} seconds left.");

        int count = 0;
        string input;
        
        int remainingTime = _duration;


        while(remainingTime > 0)
        {
            Console.WriteLine("Enter an item: ");
            input = Console.ReadLine();
            count++;
            remainingTime--;

            Pause(1);
        }

        Console.WriteLine($"You listed {count} items");
        EndActivity();
    }
}