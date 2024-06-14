using ServiceApp;

namespace ConsoleApp;
// we cannot call methods from static class as static is loading before everything
// so created this additional class to set User object
// and then we register this class in AutofacLocal as well
public class StartUp: IStartUp
{
    private IUser _user;
    
    public StartUp(IUser user)
    {
        _user = user;
    }

    public void Run()
    {
        Console.WriteLine("Starting up the execution");
        _user.CreateUser();
    }
}