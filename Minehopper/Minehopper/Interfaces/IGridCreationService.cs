using Minehopper.Models;

namespace Minehopper.Interfaces;

public interface IGridCreationService
{
    (Square[,] squares, int startX, int startY) Create(int width, int height, int numberOfMines);
}