using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Bake a Cake", "Chef Alex", 480);
        video1.AddComment(new Comment("Emily", "Great tutorial!"));
        video1.AddComment(new Comment("John", "Loved it!"));
        video1.AddComment(new Comment("Liam", "More baking videos, please!"));
        videos.Add(video1);

        Video video2 = new Video("Learn C# in 10 Minutes", "CodeAcademy", 600);
        video2.AddComment(new Comment("Alice", "Very helpful."));
        video2.AddComment(new Comment("Bob", "Do one for Python next!"));
        videos.Add(video2);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}