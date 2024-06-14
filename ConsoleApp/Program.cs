using Autofac;

// Video Reference: https://youtu.be/mCUNrRtVVWY?si=ImBPJw-8rcbKI-WP

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            
            // it configures the container which holds all the instances.
            var container = AutofacLocal.Configure();

            // setting new scope for the instances that are being passed out of the container
            using (var scope = container.BeginLifetimeScope())
            {
                // fetching an object of IStartUp
                // this stmt will internally look for all the Objects required for all the class constructors and will get the instance automatically
                var app = scope.Resolve<IStartUp>(); 
                
                // calling the method from StartUp class
                app.Run();
            }
        }
    }
}
