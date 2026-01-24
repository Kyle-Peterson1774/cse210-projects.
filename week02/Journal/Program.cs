using System;



internal class Program
{
    private static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Search entries (exceed req.)");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGen);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    try
                    {
                        journal.SaveToFile(saveFile);
                        Console.WriteLine("Journal saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Save failed: {ex.Message}");
                    }
                    break;

                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    try
                    {
                        journal.LoadFromFile(loadFile);
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Load failed: {ex.Message}");
                    }
                    break;

                case "5":
                    Console.Write("Enter a keyword to search: ");
                    string keyword = Console.ReadLine();
                    journal.Search(keyword);
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Goodbye.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        void WriteNewEntry(Journal journal, PromptGenerator promptGen)
        {
            string prompt = promptGen.GetRandomPrompt();
            Console.WriteLine();
            Console.WriteLine($"Prompt: {prompt}");

            Console.Write("Response: ");
            string response = Console.ReadLine();

            
            string date = DateTime.Now.ToShortDateString();

            
            Console.Write("Mood (Great/Okay/Rough/etc.): ");
            string mood = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(mood)) mood = "N/A";

            Console.Write("Tags (comma-separated, optional): ");
            string tags = Console.ReadLine() ?? "";

            Entry entry = new Entry(date, prompt, response, mood, tags);
            journal.AddEntry(entry);

            Console.WriteLine("Entry added.");
        }
    }
}