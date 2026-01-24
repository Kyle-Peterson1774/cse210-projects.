using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new List<string>();
    private readonly Random _random = new Random();

    public PromptGenerator()
    {
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What is something I learned today?");
        _prompts.Add("What was the strongest emotion I felt today, and why?");
        _prompts.Add("If I could redo one moment today, what would I change?");
        _prompts.Add("What progress did I make toward a goal today?");
        _prompts.Add("What am I grateful for right now?");
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
