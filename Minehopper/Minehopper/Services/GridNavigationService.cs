using Minehopper.Enums;
using Minehopper.Interfaces;
using Minehopper.Models;

namespace Minehopper.Services;

public class GridNavigationService : IGridNavigationService
{
    private readonly Dictionary<ConsoleKey, Func<bool>> _keyActionDictionary;
    private readonly Dictionary<ConsoleKey, Action> _adjustPositionActionDictionary;
    private int? _currentX, _currentY;
    private readonly IConfig _config;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public GridNavigationService(IConfig config)
    {
        _config = config;
        
        // Action to be executed to ascertain whether a movement is valid
        _keyActionDictionary = new()
        {
            { ConsoleKey.UpArrow, () => _currentY > 0 },
            { ConsoleKey.DownArrow, () => _currentY < _config.GridWidth - 1 },
            { ConsoleKey.LeftArrow, () => _currentX > 0 },
            { ConsoleKey.RightArrow, () => _currentX < _config.GridWidth - 1 }
        };

        // Action to be executed to adjust position based on key pressed
        _adjustPositionActionDictionary = new()
        {
            { ConsoleKey.UpArrow, () => _currentY-- },
            { ConsoleKey.DownArrow, () => _currentY++ },
            { ConsoleKey.LeftArrow, () => _currentX-- },
            { ConsoleKey.RightArrow, () => _currentX++ }
        };
    }

    /// <summary>
    /// Set the initial player position.  
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetPlayerPosition(int x, int y)
    {
        _currentX = x;
        _currentY = y;
    }
    
    /// <summary>
    /// Move the player's position, using the supplied squares
    /// </summary>
    /// <param name="key"></param>
    /// <param name="squares"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public MoveResult Move(ConsoleKey key, Square[,] squares)
    {
        if (_currentX == null || _currentY == null)
        {
            throw new InvalidOperationException();
        }
        
        MoveResult result;

        if (CanMove(key))
        {
            // Adjust current position
            _adjustPositionActionDictionary[key]();

            var square = squares[_currentX.Value, _currentY.Value];
            
            if (IsFinished()) // Made it to the right hand side
            {
                result = square.IsMine ? MoveResult.HitMineAndFinished : MoveResult.Finished;
            }
            else if (square.IsMine)
            {
                result = MoveResult.HitMine;

                square.IsMine = false;
            }
            else
            {
                result = MoveResult.Moved;
            }
        }
        else
        {
            result = MoveResult.UnableToMove;
        }

        return result;
    }

    /// <summary>
    /// Indicates user has finished the game if the player position is the rightmost column.  
    /// </summary>
    /// <returns></returns>
    private bool IsFinished() => _currentX == _config.GridWidth - 1;

    /// <summary>
    /// Get chess-style location of player's current position.  
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public string GetPlayerPosition()
    {
        if (_currentX == null || _currentY == null)
        {
            throw new InvalidOperationException();
        }
        char chessColumn = Alphabet[_currentX.Value];

        int chessRow = _config.GridHeight - _currentY.Value;

        return chessColumn.ToString() + chessRow;
    }

    /// <summary>
    /// True if user can move in indicated direction; otherwise false.  
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private bool CanMove(ConsoleKey key) => _keyActionDictionary[key]();
}