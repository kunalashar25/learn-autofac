using ServiceApp.Modules;

namespace ServiceApp;

public class User: IUser
{
    private IPerson _person;
    private IAddress _address;
    
    public User(IPerson person, IAddress address)
    {
        _person = person;
        _address = address;
    }
    
    public void CreateUser()
    {
        Console.WriteLine("Init User Creation");
        _person.DisplayInfo();
        _address.DisplayAddress();
    }
}