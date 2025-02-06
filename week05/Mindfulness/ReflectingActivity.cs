using System; 
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you  did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What made this time different than other times?"
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    { }

    public void StartReflectingActivity()
    {
        StartActivity();
        
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(5);

        int timeRemaining = _duration;
        while (timeRemaining > 0)
        {

            foreach (var question in questions)
        {
            Console.WriteLine(question);
            Pause(3);
            timeRemaining -=3;
            if (timeRemaining <= 0) break;
        }

    }
    
    EndActivity();
    }
}