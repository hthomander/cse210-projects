public class EternalGoal : Goal
{
    public int TotalPointsEarned { get; set; }

    public EternalGoal(string description, int points) : base(description, points)
    {
        TotalPointsEarned = 0;
    }

    public override void RecordEvent()
    {
        TotalPointsEarned += Points;
        Console.WriteLine($"Goal '{Description}' completed! You earned {Points} points. Total earned: {TotalPointsEarned} points");
    }

    public override string DisplayProgress()
    {
        return $"[ ] {Description} (Total Points Earned: {TotalPointsEarned})";
    }
}