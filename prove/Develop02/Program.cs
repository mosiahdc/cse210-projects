using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        Journal journal = new Journal();
        
        while(choice != 6)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write Entry\n2. Delete Entry\n3. Display All Entry\n4. Load\n5. Save\n6. Quit");
            Console.Write("What would you like to do? ");
            choice = int.Parse(Console.ReadLine());

            // Enter Entry
            if (choice == 1)
            {   
                Entry newEntry = new Entry();

                int entryNumber = journal.EntryNumberGenerator();
                Console.WriteLine($"Entry ID:{entryNumber}");
                
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();

                PromptGenerator promptGenerator = new PromptGenerator();
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);

                Console.Write("> ");
                string journalEntry = Console.ReadLine();

                newEntry._entryNumber = entryNumber;
                newEntry._date = dateText;
                newEntry._promptText = randomPrompt;
                newEntry._entryText = journalEntry;

                journal.AddEntry(newEntry);

            }

            // Delete an Entry
            // User can delete an entry on Journal
            // by putting the Entry Number
            else if(choice == 2)
            {
                if (journal._entries.Count > 0)
                {   
                    int removeEntry;

                    List<int> entryNumberList = journal.PopulateEntry();
                    Console.WriteLine(entryNumberList.Count);

                    Console.Write("Delete Entry #");
                    removeEntry = int.Parse(Console.ReadLine());
                    
                    if (!entryNumberList.Contains(removeEntry))
                    {
                        Console.Write($"There is no Entry #{removeEntry}\n");
                    }
                    else
                    {
                        journal.DeleteEntry(removeEntry);
                        Console.Write($"Entry Deleted\n");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Journal is empty!");
                }

            }
            
            // Display All Entry
            else if(choice == 3)
            {
                journal.DisplayAll();
            }
            
            // Load Journal Entries
            else if(choice == 4)
            {
                Console.WriteLine("What is the filename? ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
                
            }
            
            // Save Journal Entries
            else if(choice == 5)
            {
                
                Console.WriteLine("What is the filename? ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
        }
    }   
}