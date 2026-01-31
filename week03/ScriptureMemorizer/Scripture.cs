using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }

        return true;
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word w in _words)
        {
            displayWords.Add(w.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}\n{string.Join(" ", displayWords)}";
    }
}
