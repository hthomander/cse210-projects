using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }


    public void StartBreathingActivity()
    {
        StartActivity();
        
        int timeRemaining = _duration;
        while (timeRemaining > 0)
        {
            Console.WriteLine("Breathe in ...");
            Pause(3);

            Console.WriteLine("Breathe out...");
            Pause(3);

            timeRemaining -= 6;
        }
        
        EndActivity();
    }
}