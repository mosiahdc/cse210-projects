using System;

public class Event
{
    private string _title, _description, _date, _time, _type;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
        _type = GetType().Name;
    }

    public string GetStandardDetails()
    {
        return $"Event: {_title}\nDescription: {_description}\nDate: {_date} @ {_time}\nAddress: {_address.GetAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event: {_title} ({_type})\nDate: {_date} @ {_time}";
    }
}