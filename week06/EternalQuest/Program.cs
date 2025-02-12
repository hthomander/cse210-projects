using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static int TotalPointsEarned = 0;
    static void Main(string[] args) 

    {
        List<Goal> goals = LoadGoals();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║   WELCOME TO YOUR QUEST! 🎯  ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine($"Your Total Points Earned: {TotalPointsEarned}\n");

            DisplayGoals(goals);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. 🎉 Record an Event");
            Console.WriteLine("2. 🏆 Create a New Goal");
            Console.WriteLine("3. 💾 Save and Exit");
            Console.ResetColor();

            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine("Select a goal number to record an event:");
                int index = int.Parse(Console.ReadLine()) - 1;
                if (index >= 0 && index < goals.Count)
                {
                    goals[index].RecordEvent();
                    TotalPointsEarned += goals[index].Points;
                }
                else
                {
                    Console.WriteLine("⚠️ Invaild selection! Please Enter to continue ...");
                    Console.ReadLine();
                }
            }
            
            else if (option == "2")
            {
                CreateNewGoal(goals);
            }
            else if (option == "3")
            {
                SaveGoals(goals);
                break;
            }
        }
    }

    static string GetProgressBar(int current, int total, int length = 10)
    {
        int filled = (int)((double) current / total * length);
        return "[" + new string('█', filled) + new string ('-', length - filled) + $"] {current}/{total}";
    }

    static void DisplayGoals(List<Goal> goals)
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];

             if (goal is ChecklistGoal checklistGoal)
             {
                string progressBar = GetProgressBar(checklistGoal.TimesCompleted, checklistGoal.TimesRequired);
                Console.WriteLine($"{i + 1}. {progressBar} 🎯 {checklistGoal.Description}");
             }
             else
             {
            Console.WriteLine($"{i + 1}. {goal.DisplayProgress()}");
            }
        }
    }

    static void CreateNewGoal(List<Goal> goals)
    {
        Console.WriteLine("Enter the goal type (Simple, Eternal, Checklist): ");
        string type = Console.ReadLine().ToLower();

        Console.WriteLine("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the points awarded: ");
        int points = int.Parse(Console.ReadLine());

        if (type =="simple")
        {
            goals.Add(new SimpleGoal(description, points));
        }
        else if (type == "eternal")
        {
            goals.Add(new EternalGoal(description, points));
        }
        else if (type == "checklist")
        {
            Console.WriteLine("Enter the total number of times this goal is to be completed: ");
            int timesRequired = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the bonus points for completing the checklsit goal: ");
            int bonusPoints = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(description, points, timesRequired, bonusPoints));
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void SaveGoals(List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine($"simple, {simpleGoal.Description}, {simpleGoal.Points}, {simpleGoal.IsCompleted}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine($"eternal, {eternalGoal.Description}, {eternalGoal.Points}, {eternalGoal.TotalPointsEarned}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"checklist, {checklistGoal.Description}, {checklistGoal.Points},{checklistGoal.TimesCompleted},{checklistGoal.TimesRequired}, {checklistGoal.BonusPoints}");
                }
            }
        }

    Console.WriteLine("Goals saved!");

    }

    static List<Goal> LoadGoals()
    {
        List<Goal> goals = new List<Goal>();

        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string goalType = parts[0];
                    string description = parts[1];
                    int points = int.Parse(parts[2]);

                    if (goalType == "simple")
                    {
                        bool isCompleted = bool.Parse(parts[3]);
                        goals.Add(new SimpleGoal(description, points) { IsCompleted = isCompleted});
                    }
                    else if (goalType == "eternal")
                    {
                        int totalPointsEarned = int.Parse(parts[3]);
                        goals.Add(new EternalGoal(description, points) { TotalPointsEarned = totalPointsEarned});
                    }
                    else if (goalType == "checklist")
                    {
                        int timesCompleted = int.Parse(parts[3]);
                        int timesRequired = int.Parse(parts[4]);
                        int bonusPoints = int.Parse(parts[5]);
                        goals.Add(new ChecklistGoal(description, points, timesRequired, bonusPoints) { TimesCompleted = timesCompleted});
                    }
                }
            }
        }
        return goals;
    }

    static void DisplayGoalsWithIcons(List<Goal> goals)
    {
        foreach (Goal goal in goals)
        {
            string progress = goal.DisplayProgress();

            if (goal is SimpleGoal simpleGoal && simpleGoal.IsCompleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{progress} ✨");
            }
            else if (goal is EternalGoal eternalGoal)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{progress} 🔔");
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{progress} 🎯");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(progress);
            }

            Console.ResetColor();
        }
    }
}