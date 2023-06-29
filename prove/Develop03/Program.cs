using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args) 
    {

        string userInput = "";
        Scripture scripture = new Scripture();

        scripture.LoadFromFile();
        do{
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish");
            userInput = Console.ReadLine();
            if (scripture.IsCompletelyHidden() == true)
            {
                break;
            }
            else
            {
                scripture.GenerateRandomNumber();
            }
        }
        while (userInput != "quit");
    }   

}