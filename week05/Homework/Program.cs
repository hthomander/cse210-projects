using System;

class Program
{
    static void Main(string[] args)
    {
       MathAssignment mathAssignment = new MathAssignment("Jane Doe", "Fractions", "7.3", "Problems 8-19");
       Console.WriteLine(mathAssignment.GetSummary());
       Console.WriteLine(mathAssignment.GetHomeworkList());

       Console.WriteLine();

       WritingAssignment writingAssignment = new WritingAssignment("John Doe", "European History", "The Causes of World War II");
       Console.WriteLine(writingAssignment.GetSummary());
       Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}