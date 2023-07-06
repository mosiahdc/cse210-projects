using System.IO; 

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0, 
    _level = 1, 
    _pointsToLevel = 500;

    public GoalManager()
    {

    } 

    public void Start()
    {
        int userInput;

        do
        {   
            Console.Clear();
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");

            userInput = int.Parse(Console.ReadLine());
            
            if (userInput == 1)
            {
                CreateGoal();
            }
            else if (userInput == 2)
            {
                ListGoalDetails();
            }
            else if (userInput == 3)
            {
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();
                SaveGoals(filename);
            }
            else if (userInput == 4)
            {   
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();
                LoadGoals(filename);
            }
            else if (userInput == 5)
            {
                RecordEvent();
            }
            else if (userInput == 6)
            {
                break;
            }
            else
            {   
                continue;
            }
        }
        while(userInput != 6);
    }

    public void DisplayPlayerInfo()
    {   
        while (_score >= _pointsToLevel)
        {
            _level++;
            _pointsToLevel += _level * 500;
        }
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Level {_level} ({_score} points)");
        Console.WriteLine($"{_pointsToLevel - _score} more pts to Lvl {_level + 1}");
        Console.WriteLine("-------------------------");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.Write("\nNo Goal List Yet...\nPress enter to go back to Menu... ");
            Console.ReadLine();
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].GetGoalNameStatus()}");
            }
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.Write("\nNo Goal List Yet...\nPress enter to go back to Menu... ");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("The goals are:");

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
            }
            
            Console.Write("\nPress enter to go back to Menu... ");
            Console.ReadLine();
        }
    }

    public void CreateGoal()
    {  
        Goal goal = null;

        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goals");
        Console.WriteLine("  3. Checklist Goals");

        Console.Write("Which type of goal would you like to create? ");
        int userInput = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int amountPoints = int.Parse(Console.ReadLine());

        if (userInput == 1)
        {
            goal = new SimpleGoal(goalName, goalDescription, amountPoints);
        }
        else if (userInput == 2)
        {
            goal = new EternalGoal(goalName, goalDescription, amountPoints);
        }
        else if (userInput == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int goalTarget = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonusPoints = int.Parse(Console.ReadLine());

            goal = new ChecklistGoal(goalName, goalDescription, amountPoints, goalTarget, bonusPoints);
        }
        
        _goals.Add(goal);

        Console.Write("\nGoal Saved!\nPress enter to go back to Menu... ");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int userInput = int.Parse(Console.ReadLine());

        userInput -= 1;

        Goal goal = _goals[userInput];

        if (goal.GetNewPoints() == 0)
        {
            Console.WriteLine($"\nThe {goal.GetGoalName()} is already completed!");
        }
        else
        {
            int points = goal.GetNewPoints();
            goal.RecordEvent();
            
            if (goal.IsComplete())
            {
                points += goal.GetBonus();
            }

            Console.WriteLine($"\nCongratulations! You have earned {points} points!\n");

            _score += points;
            Console.WriteLine($"You now have {_score} points.");    
        }

        Console.Write("Press enter to go back to Menu... ");
        Console.ReadLine();
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {   
            writer.WriteLine(_score);
            foreach (Goal myGoal in _goals)
            {
                writer.WriteLine($"{myGoal.GetType().Name}:{myGoal.GetStringRepresentation()}");
            }
        }

        Console.Write("\nData Saved! \nPress enter to go back to Menu... ");
        Console.ReadLine();
    }

    public void LoadGoals(string filename)
    {
        Goal goal = null;
        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Count(); i++)
        {
            string[] parts = lines[i].Split(":");
            string className = parts[0];
            
            string[] goalDetail = parts[1].Split("/");
            if (className == "SimpleGoal")
            {
                goal = new SimpleGoal(goalDetail[0], goalDetail[1], int.Parse(goalDetail[2]), int.Parse(goalDetail[3]), bool.Parse(goalDetail[4]));
            }
            else if (className == "EternalGoal")
            {
                goal = new EternalGoal(goalDetail[0], goalDetail[1], int.Parse(goalDetail[2]));
            }
            else if (className == "ChecklistGoal")
            {
                goal = new ChecklistGoal(goalDetail[0], goalDetail[1], int.Parse(goalDetail[2]), int.Parse(goalDetail[3]), int.Parse(goalDetail[4]), int.Parse(goalDetail[5]), int.Parse(goalDetail[6]));
            }

            _goals.Add(goal);
        }  
        Console.Write("\nData Loaded! \nPress enter to go back to Menu... ");
        Console.ReadLine();
    }
}