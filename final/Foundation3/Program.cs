using System;

class Program
{
    static void Main(string[] args)
    {

        List<Event> events = new List<Event>();

        Address lectureAddress = new Address("2909 Stratford Drive", "Kailua", "Hawaii", "USA");
        events.Add(new Lecture("Young Innovator Summit", "Shaping the future of young innovators", "October 8, 2023", "8:00 AM", lectureAddress, "Johnny Depth", 500));

        Address receptionAddress = new Address("Tungkong Mangga", "San Jose Dela Monte", "Bulacan", "Philippines");
        string email = "We cordially invite you to our wedding reception and celebrate with us.";
        events.Add(new Reception("Erica & Mosiah Reception", "Celebrate the union of Erica & Mosiah", "December 20, 2016", "6:00 PM", receptionAddress, email));

        Address outdoorAddress = new Address("Walker and Robinson streets", "Melbourne", "Victoria", "Australia");
        events.Add(new OutdoorGathering("StaffBerry Summer Fair", "Enjoy a day of family-friendly activities", "November 12, 2023", "10:00 AM", outdoorAddress, "Sunny"));


        foreach (Event eventDetail in events)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");
            Console.WriteLine(eventDetail.GetStandardDetails());
            Console.WriteLine("---------------------------------");
            Console.WriteLine(eventDetail.GetFullDetails());
            Console.WriteLine("---------------------------------");
            Console.WriteLine(eventDetail.GetShortDescription());
            Console.WriteLine("+++++++++++++++++++++++++++++++++++\n");
        }
    }
}