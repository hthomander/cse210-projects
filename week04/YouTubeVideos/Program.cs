using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Comment comment1 = new Comment("Alice", "Great View!");
        Comment comment2 = new Comment("Bob", "Very Informative.");
        Comment comment3 = new Comment("Charlie", "I learned a lot, thanks!");

        Video video1 = new Video("Understanding C#", "Hazel Beth", 600);
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);

        Console.WriteLine($"Title: {video1.Title}");
        Console.WriteLine($"Author: {video1.Author}");
        Console.WriteLine($"Length: {video1.Length} seconds");
        Console.WriteLine($"Number of comments: {video1.GetNumberOfComments()}");
        video1.DisplayComments();

        Comment comment4 = new Comment("Dave", "Amazing content!");
        Video video2 = new Video("Mastering Algorithms", "Hazel Thomander", 720);
        video2.AddComment(comment4);

        Console.WriteLine("\nTitle: " + video2.Title);
        Console.WriteLine("Author: " + video2.Author);
        Console.WriteLine("Length: " + video2.Length + "seconds");
        Console.WriteLine("Number of comments: " + video2.GetNumberOfComments());
        video2.DisplayComments();
    }
}