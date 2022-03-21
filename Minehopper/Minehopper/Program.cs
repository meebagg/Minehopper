using Minehopper.Interfaces;
using Splat;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Register depencies
            Bootstrapper.Register();

            // Start the game running
            Locator.Current.GetService<IGameService>()?.Run();
        }
    }
}