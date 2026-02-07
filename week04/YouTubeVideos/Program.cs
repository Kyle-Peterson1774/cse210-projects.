using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Creatine Gummies Explained", "MAXD Lab", 420);
        v1.AddComment(new Comment("Alex", "This actually makes sense."));
        v1.AddComment(new Comment("Jordan", "Way easier than powder."));
        v1.AddComment(new Comment("Taylor", "Love the breakdown."));
        videos.Add(v1);

        Video v2 = new Video("Hyrox Engine Builder Workout", "Peak Pace", 615);
        v2.AddComment(new Comment("Sam", "That sled push was brutal."));
        v2.AddComment(new Comment("Chris", "Subbed instantly."));
        v2.AddComment(new Comment("Mia", "Can you post weekly plans?"));
        videos.Add(v2);

        Video v3 = new Video("Recovery Mistakes You’re Making", "Recover Smart", 540);
        v3.AddComment(new Comment("Nina", "Sleep is definitely my issue."));
        v3.AddComment(new Comment("Ben", "Great reminder about hydration."));
        v3.AddComment(new Comment("Liam", "Magnesium content next?"));
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.CommenterName}: {comment.Text}");
            }
        }
    }
}
