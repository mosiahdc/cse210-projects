
public class ReflectingActivity : Activity
{    
    private List<string> _prompts = new List<string>
    {
        " --- Think of a time when you stood up for someone else. ---", 
        " --- Think of a time when you did something really difficult. ---",
        " --- Think of a time when you helped someone in need. ---",
        " --- Think of a time when you did something truly selfless. ---"
    };
    
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you? ", 
        "Have you ever done anything like this before? ", 
        "How did you get started? ",
        "How did you feel when it was complete? ",
        "What made this time different than other times when you were not as successful? ",
        "What is your favorite thing about this experience? ",
        "What could you learn from this experience that applies to other situations? ",
        "What did you learn about yourself through this experience? ",
        "How can you keep this experience in mind in the future? "
    };

    public ReflectingActivity(string name, string description) : base(name, description)
    {

    }

    public override void Run ()
    {
        Console.Clear();
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt: \n");

        DisplayPrompt();

        Console.WriteLine("When you have something in mind, please press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        while((DateTime.Now - startTime).TotalSeconds < GetTime())
        {
            DisplayQuestions();
        }
        DisplayEndingMessage();

        _reflectingCount++;
    }

    public string GetRandomPrompt()
    {   
        int random = _rand.Next(_prompts.Count);
        return _prompts[random];
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine();
    }

    public string GetRandomQuestion()
    {
        int random = _rand.Next(_questions.Count);
        string question = _questions[random];
        _questions.RemoveAt(random);
        return question;
    }

    public void DisplayQuestions()
    {
        string questions = GetRandomQuestion();
        Console.Write(questions);
        ShowSpinner(15);
        Console.WriteLine();
    }
}