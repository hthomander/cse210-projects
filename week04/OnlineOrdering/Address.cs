using System;

public class Address 
{
    public string Street {get; set;}
    public string City {get; set;}
    public string State {get; set;}
    public string Country {get; set;}

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}