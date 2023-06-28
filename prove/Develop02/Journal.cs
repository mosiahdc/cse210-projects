using System;
using System.IO; 

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Populate local List
    public List<int> PopulateEntry()
    {
        List<int> tempEntryNumber = new List<int>();
        foreach (Entry entry in _entries)
        {
            tempEntryNumber.Add(entry._entryNumber);
        }

        return tempEntryNumber;
    }
    
    // Generate Random Number
    // As Entry Number
    public int EntryNumberGenerator()
    {
        Random random = new Random();

        List<int> entryNumberList = PopulateEntry();

        int randomNumber;
        
        do
        {
            randomNumber= random.Next(1001, 10000);
        } 
        while (entryNumberList.Contains(randomNumber));

        return randomNumber;
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Remove Entry
    public void DeleteEntry(int removeEntry)
    {

        List<int> entryNumberList = PopulateEntry();

        Console.WriteLine(entryNumberList.Count);

        int entryIndex = entryNumberList.IndexOf(removeEntry);
        _entries.RemoveAt(entryIndex);
    }

    public void DisplayAll()
    {   
        if (_entries.Count > 0)
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
        else
        {
            Console.WriteLine("Journal is empty!");
        }
        
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                
                int entryNumber = entry._entryNumber;
                string date =  entry._date;
                string promptText =  entry._promptText;
                string entryText =  entry._entryText;

                outputFile.WriteLine($"{entryNumber}\n{date}\n{promptText}\n{entryText}");
                
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);

        int entryNumber = 0;
        string date = "";
        string promptText = "";
        string entryText = "";
        int lineCount = 0;

        foreach (string line in lines)
        {
            lineCount++;

            if ((lineCount % 4) == 1)
            {
                entryNumber = int.Parse(line);
            }
            else if ((lineCount % 4) == 2)
            {
                date = line;
            }
            else if ((lineCount % 4) == 3)
            {
                promptText = line;
            }
            else if ((lineCount % 4) == 0)
            {

                entryText = line;

                Entry loadEntry = new Entry();

                loadEntry._entryNumber = entryNumber;
                loadEntry._date = date;
                loadEntry._promptText = promptText;
                loadEntry._entryText = entryText;

                _entries.Add(loadEntry);

            }
        }
    }
}