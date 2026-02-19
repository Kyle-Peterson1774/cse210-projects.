using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("18 Feb 2026", 30, 3.0),
            new Cycling("18 Feb 2026", 45, 15.0),
            new Swimming("18 Feb 2026", 40, 30)
        };

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
