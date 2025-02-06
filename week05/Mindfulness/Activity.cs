using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {_name} ...");
        Console.WriteLine($"{_description}");
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
       string[] spinChars = { "|", "/", "-", "\\"};
       int spinIndex = 0; 


        for (int i = 0; i < seconds; i++)
        {
            Console.Write(spinChars[spinIndex]);
            Console.Write("\b");

            spinIndex = (spinIndex + 1) % spinChars.Length;
            Thread.Sleep(1000);

            Console.Write($"{seconds - i} seconds remaining... \r");
            Thread.Sleep(1000);
            Console.Clear();
        }
        Console.WriteLine();
    }
}