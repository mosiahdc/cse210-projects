
public abstract class Goal
{
    private string _shortName, _description;
    private int _points, _newPoints;

    public Goal(string name, string description, int newPoints, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _newPoints = newPoints;
    } 

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _newPoints = points;
    }   

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    public string GetGoalName()
    {
        return $"{_shortName}";
    }

    public string GetGoalNameStatus()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName}";
    }

    public string GetGoalDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public int GetNewPoints()
    {
        return _newPoints;
    }

    public void SetPoints(int points)
    {
        _newPoints = points;
    }

    public virtual int GetBonus()
    {
        return 0;
    }

}