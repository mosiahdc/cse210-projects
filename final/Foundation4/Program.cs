using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        DateTime date = DateTime.Now;
        activities.Add(new Running(date, 60, 8));
        activities.Add(new Cycling(date, 30, 3));
        activities.Add(new Swimming(date, 20, 10));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}