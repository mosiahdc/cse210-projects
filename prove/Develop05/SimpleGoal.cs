
public class SimpleGoal : Goal
{
    private bool _isComplete;     
    
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {

    } 

    public SimpleGoal(string name, string description, int newPoints, int points, bool IsComplete) : base(name, description, newPoints, points)
    {
        _isComplete = IsComplete;
    } 

    public override void RecordEvent()
    {
        _isComplete = true;
        SetPoints(0);
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalName()}/{GetGoalDescription()}/{GetNewPoints()}/{GetPoints()}/{_isComplete}";
    }
}