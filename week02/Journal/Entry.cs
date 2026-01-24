using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }
    public string Tags { get; set; }
    public Entry() { }

    public Entry(string date, string prompt, string response, string mood, string tags)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Tags = tags;
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Date:   {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Mood:   {Mood}");
        Console.WriteLine($"Tags:   {Tags}");
        Console.WriteLine($"Entry:  {Response}");
    }
    // this is my format idea: Date~|~Prompt~|~Response~|~Mood~|~Tags
    public string ToFileString()
    {
        return $"{Escape(Date)}~|~{Escape(Prompt)}~|~{Escape(Response)}~|~{Escape(Mood)}~|~{Escape(Tags)}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("~|~");
        string date = parts.Length > 0 ? Unescape(parts[0]) : "";
        string prompt = parts.Length > 1 ? Unescape(parts[1]) : "";
        string response = parts.Length > 2 ? Unescape(parts[2]) : "";
        string mood = parts.Length > 3 ? Unescape(parts[3]) : "N/A";
        string tags = parts.Length > 4 ? Unescape(parts[4]) : "";

        return new Entry(date, prompt, response, mood, tags);
    }
    private static string Escape(string value)
    {
        if (value == null) return "";
        return value.Replace("\n", "\\n").Replace("\r", "\\r").Replace("~|~", "~\\|~");
    }

    private static string Unescape(string value)
    {
        if (value == null) return "";
        return value.Replace("~\\|~", "~|~").Replace("\\r", "\r").Replace("\\n", "\n");
    }
}
