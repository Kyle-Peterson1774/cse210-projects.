#nullable enable
using System;

class Program
{
    static void Main(string[] args)
    {
        int sessionsCompleted = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine() ?? "";

            Activity? activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectingActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (choice == "4")
                break;

            if (activity == null)
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            activity.Run();
            sessionsCompleted++;

            Console.WriteLine();
            Console.WriteLine($"Session log (this run): {sessionsCompleted} activities completed.");
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
