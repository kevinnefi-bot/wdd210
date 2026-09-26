using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Encapsulation Explained", "Code Academy", 600);
        video1.AddComment(new Comment("Carlos123", "Great explanation of private member variables!"));
        video1.AddComment(new Comment("Sofia_Dev", "This made abstraction so much easier to understand."));
        video1.AddComment(new Comment("Alex_G", "Can you make a video about inheritance next?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 VS Code Extensions in 2026", "TechTalks", 450);
        video2.AddComment(new Comment("JohnDoe", "Prettier and C# Dev Kit are absolute essentials!"));
        video2.AddComment(new Comment("MariaR", "Thanks for recommending number 4, it saved me hours."));
        video2.AddComment(new Comment("PixelKing", "Subscribed! Really high quality video."));
        video2.AddComment(new Comment("DevGuru", "Awesome list as always."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Building Your First Object-Oriented App", "Programming with Classes", 900);
        video3.AddComment(new Comment("Lucia_M", "Clear, concise, and straight to the point."));
        video3.AddComment(new Comment("KevinNefi", "I love how cleanly the classes are separated."));
        video3.AddComment(new Comment("Beatriz_88", "Very helpful for my homework assignment!"));
        videos.Add(video3);

        // Recorrer la lista de videos e imprimir los datos
        foreach (Video video in videos)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"Title:  {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: \"{comment.GetText()}\"");
            }
            Console.WriteLine();
        }
    }
}