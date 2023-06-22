using System;

public class Entry
{
    public int _entryNumber;
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {

        Console.WriteLine($"Entry #{_entryNumber}");
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");

        Console.WriteLine();
    }
}