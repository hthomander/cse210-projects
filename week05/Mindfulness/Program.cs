using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("Welcome to the Activity Program!");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Select an activity (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.StartBreathingActivity();
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.StartReflectingActivity();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.StartListingActivity();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Thank you for using the Activity Program! Have a nice day!");
                    break;
                default: 
                    Console.WriteLine("Invalid choice, please try again.");
                    break;

            }
        }
    }
}