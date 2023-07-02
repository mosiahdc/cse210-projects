
public abstract class Activity
{

    private string _name, _description;
    private int _duration;
    protected static int _breathingCount, _reflectingCount, _listingCount;
    
    List<string> animationStrings = new List<string>()
    {
        "|","/","-","\\","|","/","-","\\"
    };

    protected static Random _rand = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;    
    }
    
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine($"{_description}");
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("Get ready... ");
        ShowSpinner(4);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell Done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of {_name} Activity.");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = (seconds * (int)2.5); i > 0; i--)
        {
            Console.Write(animationStrings[i % 8]);
            Thread.Sleep(400);
            Console.Write("\b \b");
        };
    }

    public void ShowCountDown(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while(DateTime.Now < endTime)
        {
            Console.Write(seconds);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            seconds--;
        }
    }
    
    public int GetTime()
    {
        return _duration;
    }

    public abstract void Run(); 

    public static void ActivityLog()
    {   
        Console.Clear();
        List<string> activityCount = new List<string>
        {
            "Breathing", "Reflecting", "Listing"
        };

        Console.WriteLine("Activity Log");
        for (int x = 0; x < 3; x ++)
        {
            Console.Write($"\n{activityCount[x]} Count: ");
            for (int i = 15; i > 0; i--)
            {   
                int random1 = _rand.Next(10);
                
                Console.Write(random1);
                Thread.Sleep(100);
                Console.Write("\b \b");
            }

            if (x == 0)
            {
                Console.Write(_breathingCount);
            }
            else if (x == 1)
            {
                Console.Write(_reflectingCount);
            }
            else if (x == 2)
            {
                Console.Write(_listingCount);
            }
        }

        Console.WriteLine("\n\nPress enter to go back to Menu");
        Console.ReadLine();
        Console.Clear();
         
    }
}