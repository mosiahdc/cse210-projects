
public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }

    public override void Run ()
    {   
        Console.Clear();
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;

        while((DateTime.Now - startTime).TotalSeconds <GetTime())
        {
            Console.Write("\n\nBreathe in... ");
            ShowCountDown(5);

            Console.Write("\nNow breathe out... ");
            ShowCountDown(5);
        }
        Console.WriteLine();
        DisplayEndingMessage();

        _breathingCount++;

    }

    
}