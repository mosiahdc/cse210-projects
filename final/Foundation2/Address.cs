using System;

public class Address
{
    private string _street, _city, _state, _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _state = stateOrProvince;
        _country = country;
    }

    public bool IsUSA()
    {
        return _country.Contains("USA");
    }
    
    public string GetDetailAddress()
    {
        return $"{_street}, {_city},\n{_state}, {_country}";
    }
}