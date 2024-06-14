namespace ServiceApp.Modules;

public class Address: IAddress
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public void DisplayAddress()
    {
        Console.WriteLine($"Address info");
    }
}
