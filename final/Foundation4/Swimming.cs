using System;

public class Swimming : Activity
{
    private int _lap;

    public Swimming(DateTime date, int length, int lap) : base (date, length)
    {
        _lap = lap;
    }

    public override double GetDistance()
    {
        return (_lap * 50) / (1000 * 0.62);
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLength() ) * 60;
    }

    public override double GetPace()
    {
        return GetLength() / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }  
}