using System;

public class Running : Activity
{
    private double _distance;
    public Running(DateTime date, int length, double distance) : base (date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetSpeed()
    {
       return (_distance / GetLength()) * 60;
    }

    public override double GetPace()
    {
        return GetLength() / _distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}