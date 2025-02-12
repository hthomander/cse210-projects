public class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }

    public SimpleGoal(string description, int points) : base(description, points)
    {
        IsCompleted = false;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Description}' completed! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{Description}' has already been completed.");
        }
    }

    public override string DisplayProgress()
    {
        return IsCompleted ? "[X] " + Description : "[ ] " + Description;
    }
}