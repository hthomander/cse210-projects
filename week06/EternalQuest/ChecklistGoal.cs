public class ChecklistGoal : Goal
{
    public int TimesCompleted { get;  set; }
    public int TimesRequired { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string description, int points, int timesRequired, int bonusPoints) : base(description, points)
    {
        TimesCompleted = 0;
        TimesRequired = timesRequired;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        TimesCompleted++;
        int pointsEarned = Points;

        if (TimesCompleted == TimesRequired)
        {
            pointsEarned += BonusPoints;
            Console.WriteLine($"Goal '{Description}' completed! You earned {Points} points and a bonus of {BonusPoints} points!");
        }
        else
        {
            Console.WriteLine($"Goal '{Description}' completed! You earned {Points} points.");
        }
        Console.WriteLine($"Progress: {TimesCompleted}/{TimesRequired}");
    }

    public override string DisplayProgress()
    {
        return $"[ ] {Description} (Completed {TimesCompleted}/{TimesRequired} times)";
    }
}