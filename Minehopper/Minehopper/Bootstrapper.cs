using Minehopper.Configs;
using Minehopper.Interfaces;
using Minehopper.Services;
using Splat;
using Splat.ReactiveUIExtensions;

namespace MyApp;

public class Bootstrapper
{
    public static void Register()
    {
        Locator.CurrentMutable.RegisterLazySingleton<GameService, IGameService>();
        Locator.CurrentMutable.RegisterLazySingleton<GridService, IGridService>();
        Locator.CurrentMutable.RegisterLazySingleton<GridCreationService, IGridCreationService>();
        Locator.CurrentMutable.RegisterLazySingleton<DefaultConfig, IConfig>();
        Locator.CurrentMutable.RegisterLazySingleton<GridNavigationService, IGridNavigationService>();
    }
}