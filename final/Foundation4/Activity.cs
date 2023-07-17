using System;

public abstract class Activity
{
    private DateTime _date = DateTime.Now;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"\n{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_length}) min";
    }
}