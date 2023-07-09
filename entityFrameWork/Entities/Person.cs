namespace programm.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public Address(string city, string country)
    {
        
        City = city;
        Country = country;
    }

    public int id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class Sponsor
{

    public int id { get; set; }
    public byte[] image { get; set; }
}