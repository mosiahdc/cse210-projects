using System;

public class Cycling : Activity
{
    private double _speed;
    public Cycling(DateTime date, int length, double speed) : base (date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetLength()) / 60;
    }  
    
    public override double GetSpeed()
    {
        return _speed;
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