using System;

publics class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }


    public void StartBreathingActivity()
    {
        StartActivity();
        Console.WriteLine("Breathe in ...");
        Pause(3);
        Console.WriteLine("Breathe out...");
        Pause(3);
        EndActivity();
    }
}