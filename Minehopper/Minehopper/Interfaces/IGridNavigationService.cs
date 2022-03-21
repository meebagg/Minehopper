using Minehopper.Enums;
using Minehopper.Models;

namespace Minehopper.Interfaces;

public interface IGridNavigationService
{
    MoveResult Move(ConsoleKey key, Square[,] squares);
    string GetPlayerPosition();
    void SetPlayerPosition(int x, int y);
}