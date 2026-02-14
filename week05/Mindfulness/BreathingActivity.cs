using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        int duration = GetDurationSeconds();
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(4);
            Console.WriteLine();

            if (DateTime.Now >= end) break;

            Console.Write("Breathe out... ");
            ShowCountDown(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
