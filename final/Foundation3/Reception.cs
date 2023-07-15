using System;

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string email): base (title, description, date, time, address)
    {
        _rsvpEmail = email;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nRSVP: \"{_rsvpEmail}\"";
    }
}