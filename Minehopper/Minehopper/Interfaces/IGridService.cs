using Minehopper.Enums;

namespace Minehopper.Services;

public interface IGridService
{
    string GetPlayerPosition();
    MoveResult Move(ConsoleKey key);
}