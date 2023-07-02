
public class ListingActivity : Activity
{   
    private int _count;
    private List<string> _prompts = new List<string>
    {
        " --- Who are People that you appreciate? ---",
        " --- What are personal strengths of yours? ---",
        " --- Who are people that you have helped this week? ---",
        " --- When have you felt the holy Ghost this month? ---",
        " --- Who are some of your personal heroes? ---"
    };

    public ListingActivity(string name, string description) : base(name, description)
    {

    }

    public override void Run ()
    {
        Console.Clear();
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses you can to the following prompt: ");
        Console.WriteLine(GetRandomPrompt());
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        GetListFromUser();  
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();

        _listingCount++;
    }

    public string GetRandomPrompt()
    {   
        int random = _rand.Next(_prompts.Count);
        return _prompts[random];
    }

    public List<string> GetListFromUser()
    {
        Console.WriteLine();
        List<string> list = new List<string>();

        DateTime _startTime = DateTime.Now;
        while((DateTime.Now - _startTime).TotalSeconds <GetTime())
        {
            Console.Write("> ");
            list.Add(Console.ReadLine());
            _count++;
        }    
        return list;
    }
}