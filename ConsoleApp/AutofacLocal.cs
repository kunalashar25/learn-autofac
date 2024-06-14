using System.Reflection;
using Autofac;
using ConsoleApp;
using ServiceApp;


public static class AutofacLocal
{

    public static IContainer Configure()
    {
        // place to store key-value pair list of all the classes we want to instantiate
        var builder = new ContainerBuilder();
        
        // whenever it looks for IUser, it returns instance of User class
        builder.RegisterType<User>()
               .As<IUser>();
        
        // Register StartUp class which will run our actual program
        builder.RegisterType<StartUp>()
               .As<IStartUp>();
        
        // if we have a lot of classes, writing above stmt one by one can be tiring, we can automate this process as below
        builder.RegisterAssemblyTypes(Assembly.Load(nameof(ServiceApp)))
               .Where(t => t.Namespace.Contains("Modules")) // registering all the classes in Modules
               .As(t => t.GetInterfaces() // link them to the matching I interface
                         .FirstOrDefault(i => i.Name == "I" + t.Name));
        
        // builds the continer
        return builder.Build();
    }
}

// Use this code to further debug incase of any errors
/*
try
{
    // Automate registration for types in the 'Modules' namespace
    var assembly = Assembly.Load(nameof(ServiceApp));
    var types = assembly.GetTypes()
                        .Where(t => t.Namespace != null && t.Namespace.Contains("Modules"))
                        .ToArray();

    foreach (var type in types)
    {
        Console.WriteLine($"Registering type: {type.FullName}");
        var interfaces = type.GetInterfaces();
        var matchingInterface = interfaces.FirstOrDefault(i => i.Name == "I" + type.Name);

        if (matchingInterface != null)
        {
            builder.RegisterType(type).As(matchingInterface);
            Console.WriteLine($"Linked {type.FullName} to {matchingInterface.FullName}");
        }
        else
        {
            Console.WriteLine($"No matching interface found for {type.FullName}");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error during registration: {ex.Message}");
    throw;
}
*/
