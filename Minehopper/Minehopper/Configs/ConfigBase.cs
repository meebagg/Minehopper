using Minehopper.Interfaces;

namespace Minehopper.Configs;

public class ConfigBase : IConfig
{
    public ConfigBase(int gridWidth, int gridHeight, int numberOfMines, int totalLives)
    {
        GridWidth = gridWidth;

        GridHeight = gridHeight;

        NumberOfMines = numberOfMines;

        TotalLives = totalLives;
    }

    public int GridWidth { get; }
    public int GridHeight { get; }
    public int NumberOfMines { get; }
    public int TotalLives { get; }
}