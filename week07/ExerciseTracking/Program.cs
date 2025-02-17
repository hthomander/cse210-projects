using System;
using System.Collections.Generic;

class Program
{
    static List<Activity> activities = new List<Activity>();
    static void Main()
    {
       Console.WriteLine("📊  Welcome to the Exercise Tracking Program!");

       while (true)
       {
        Console.WriteLine("\n📋 Please choose an option:");
        Console.WriteLine("1️⃣ Add Running Activity 🏃‍♂️");
        Console.WriteLine("2️⃣ Add Cycling Activity 🚴‍♀️");
        Console.WriteLine("3️⃣ Add Swimming Activity 🏊‍♂️");
        Console.WriteLine("4️⃣ View Activity Summary 👀");
        Console.WriteLine("5️⃣ Save and Exit 💾 & 👋");
        Console.Write("👉 Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddRunningActivity();
                break;
            case "2":
                AddCyclingActivity();
                break;
            case "3":
                AddSwimmingActivity();
                break;
            case "4":
                DisplayActivities();
                break;
            case "5":
                Console.WriteLine("👋 Goodbye! Stay active! 💪");
                return;
            default:
                Console.WriteLine("⚠️ Invaild choice, please try again.");
                break;
            }
       }
    }

   
    static void AddRunningActivity()
    {
        Console.Write("🗓️ Please enter date of run (yyyy-mm-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("⏱️ Enter duration of run in minutes:");
        int duration = int.Parse(Console.ReadLine());
        Console.Write("📏 Enter distance of run in miles:");
        double distance = double.Parse(Console.ReadLine());
        activities.Add(new Running(date, duration, distance));
        Console.WriteLine("🏃‍♂️ Running activity added!");
    }

    static void AddCyclingActivity()
    {
        Console.Write("🗓️ Please enter date of cycle (yyyy-mm-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("⏱️ Enter duration of cycle in minutes:");
        int duration = int.Parse(Console.ReadLine());
        Console.Write("🦵 Enter speed of cycle in mph:");
        double speed = double.Parse(Console.ReadLine());
        activities.Add(new Cycling(date, duration, speed));
        Console.WriteLine("🚴‍♂️ Cycling activity added!");
    }

    static void AddSwimmingActivity()
    {
         Console.Write("🗓️ Please enter date of swim (yyyy-mm-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("⏱️ Enter duration of swim in minutes:");
        int duration = int.Parse(Console.ReadLine());
        Console.Write("🏊 Enter number of laps during swim:");
        int laps = int.Parse(Console.ReadLine());
        activities.Add(new Swimming(date, duration, laps));
        Console.WriteLine("🏊‍♂️ Swimming activity added!");
    }

    static void DisplayActivities()
    {
        Console.WriteLine("\n📅 Activity Summary:");
        if (activities.Count == 0)
        {
            Console.WriteLine("⚠️ No activities recorded yet.");
            return;
        }
         foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}