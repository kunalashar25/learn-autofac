namespace ServiceApp.Modules;

public class Person: IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Person Info");
    }
}
