using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Bake Bread", "Alice Baker", 300);
        video1.AddComment(new Comment("John", "This was really helpful!"));
        video1.AddComment(new Comment("Maria", "Thanks for the tips."));
        video1.AddComment(new Comment("Leo", "Can you show a gluten-free version?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Morning Yoga Routine", "YogaWithSam", 600);
        video2.AddComment(new Comment("Nina", "So relaxing, thank you."));
        video2.AddComment(new Comment("Carlos", "Perfect for beginners."));
        video2.AddComment(new Comment("Lily", "I do this every morning now."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Learn C# in 10 Minutes", "CodeLab", 700);
        video3.AddComment(new Comment("Aaron", "Best quick tutorial ever!"));
        video3.AddComment(new Comment("Dani", "Very clear explanations."));
        video3.AddComment(new Comment("Mike", "I learned so much!"));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplay());
            Console.WriteLine("----------------------------");
        }
    }
}
