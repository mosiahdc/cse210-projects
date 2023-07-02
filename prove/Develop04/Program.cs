using System;
class Program
{
    public static void Main(string[] args)
    {
        int userInput;

        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Activities Log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            userInput = int.Parse(Console.ReadLine());

            Activity activity = null;
            string name, description;

            if (userInput == 1)
            {
                name = "Breathing";
                description = "\nThis activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. ";

                activity = new BreathingActivity(name, description);
            }
            else if (userInput == 2)
            {
                name = "Reflecting";
                description = "\nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

                activity = new ReflectingActivity(name, description);
            }
            else if (userInput == 3)
            {
                name = "Listing";
                description = "\nThis activity will help you reflect on good things in your life by having you list as many things as you can in a certain area.";

                activity = new ListingActivity(name, description);
            }
            else if (userInput == 4)
            {
                Activity.ActivityLog();
            }
            else if (userInput == 5)
            {
                break;
            }
            else
            {   
                Console.Clear();
                continue;
            }

            if (userInput < 4 && userInput > 0)
            {
                activity.Run();
            }
        }
        while(userInput != 5);        
    }
}