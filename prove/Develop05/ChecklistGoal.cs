
public class ChecklistGoal : Goal
{
    private int _amountCompleted, _target, _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }
    
    public ChecklistGoal(string name, string description, int newPoints, int points, int bonus, int target, int amountCompleted) : base(name, description, newPoints, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }       

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            SetPoints(0);
        }
    }

    public override int GetBonus()
    {
        return _bonus;
    }
    
    public override bool IsComplete()
    {
        bool status;

        if (_amountCompleted == _target)
        {
            status = true;
        }
        else
        {
            status = false;
        }
        return status;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetGoalName()} ({GetGoalDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalName()}/{GetGoalDescription()}/{GetNewPoints()}/{GetPoints()}/{_bonus}/{_target}/{_amountCompleted}";
    }
}