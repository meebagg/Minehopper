using Minehopper.Interfaces;
using Minehopper.Models;

namespace Minehopper.Services;

/// <summary>
/// This class is used to create a new Square 2D array to represent the minefield.  
/// Returns the Square array, along with the player's starting position.  
/// </summary>
public class GridCreationService : IGridCreationService
{
    public (Square[,] squares, int startX, int startY) Create(int width, int height, int numberOfMines)
    {
        var squares = new Square[width, height];

        // Populate array
        for (int column = 0; column < width; column++)
        {
            for (int row = 0; row < height; row++)
            {
                squares[column, row] = new Square();
            }
        }
        
        // Set start position
        int startColumn = 0;
        int startRow = height / 2;
        startRow += height % 2; // Center in the the leftmost column if uneven number of rows

        Random random = new Random();

        // Set required number of squares as mines
        for (int i = 0; i < numberOfMines; i++)
        {
            var mineColumn = random.Next(1, width);

            var mineRow = random.Next(1, height);

            var selectedSquare = squares[mineColumn, mineRow];

            if (mineColumn == startColumn && mineRow == startRow || selectedSquare.IsMine)
            {
                // Collision, so find next free space
                var nextFreeSquare = FindNextFreeSquare(selectedSquare, squares);

                nextFreeSquare.IsMine = true;
            }
            else
            {
                squares[mineColumn, mineRow].IsMine = true;
            }
        }
        
        // Return starting position
        return (squares, startColumn, startRow);
    }

    private Square FindNextFreeSquare(Square selectedSquare, Square[,] squares)
    {
        var list = squares.Cast<Square>().ToList();

        var indexOf = list.IndexOf(selectedSquare);

        Square firstFreeSquare;

        try
        {
            firstFreeSquare = list.Skip(indexOf + 1).First(x => !x.IsMine);
        }
        catch (InvalidOperationException) // Not found, so start from the beginning
        {
            firstFreeSquare = list.First(x => !x.IsMine);
        }

        return firstFreeSquare;
    }
}