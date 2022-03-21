namespace Minehopper.Interfaces;

public interface IConfig
{
    int GridWidth { get; }
    int GridHeight { get; }
    int NumberOfMines { get; }
    int TotalLives { get; }
}