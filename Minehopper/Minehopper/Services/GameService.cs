using Minehopper.Enums;
using Minehopper.Interfaces;

namespace Minehopper.Services
{
    /// <summary>
    /// This class loops waiting for input from the user and passes valid movement input
    /// to the GridService.  
    /// </summary>
    public class GameService : IGameService
    {
        private readonly IGridService _gridService;
        private int _lives, _movesTaken;

        private readonly List<ConsoleKey> _validKeys = new()
        {
            ConsoleKey.UpArrow,
            ConsoleKey.DownArrow,
            ConsoleKey.LeftArrow,
            ConsoleKey.RightArrow,
            ConsoleKey.E
        };

        public GameService(IConfig config, IGridService gridService)
        {
            // Initialise grid
            _gridService = gridService;

            _lives = config.TotalLives;
        }

        public void Run()
        {
            bool isRunning = true;
            
            var currentLocationMessage = string.Format(Resources.CurrentLocationMessage, _gridService.GetPlayerPosition());
                
            Console.WriteLine(currentLocationMessage);

            // Keep waiting for input until isRunning is false
            while (isRunning)
            {
                Console.WriteLine(Resources.Instructions);

                // Read a single key from the keyboard
                ConsoleKeyInfo key = Console.ReadKey(false);

                // If invalid, loop around again
                if (IsInvalidKey(key.Key))
                {
                    Console.WriteLine(Resources.InvalidKeyMessage);

                    continue;
                }

                // Newline
                Console.WriteLine();

                // Exit if user tapped 'e'
                if (ShouldExit(key))
                {
                    isRunning = false;

                    continue;
                }

                // Make a move and switch on the result
                MoveResult moveResult = _gridService.Move(key.Key);

                switch (moveResult)
                {
                    case MoveResult.HitMineAndFinished:
                        _movesTaken++;
                        var hitMineAndWonMessage = string.Format(Resources.HitMineAndWonMessage, _lives, _movesTaken);
                        Console.WriteLine(hitMineAndWonMessage);
                        isRunning = false;
                        break;
                    case MoveResult.Finished:
                        _movesTaken++;
                        var wonMessage = string.Format(Resources.WonMessage, _lives, _movesTaken);
                        Console.WriteLine(wonMessage);
                        isRunning = false;
                        break;
                    case MoveResult.Moved:
                        _movesTaken++;
                        var movedMessage = string.Format(Resources.MovedMessage, _gridService.GetPlayerPosition(), _lives,
                            _movesTaken);
                        Console.WriteLine(movedMessage);
                        break;
                    case MoveResult.HitMine:
                        _lives--;
                        _movesTaken++;

                        // All lives gone - game over
                        if (_lives == 0)
                        {
                            var deadMessage = string.Format(Resources.DeadMessage, _movesTaken);
                            
                            Console.WriteLine(deadMessage);

                            isRunning = false;
                        }
                        else
                        {
                            var boomMessage = string.Format(Resources.BoomMessage, _lives, _movesTaken);

                            Console.WriteLine(boomMessage);
                        }

                        break;
                    case MoveResult.UnableToMove:
                        Console.WriteLine(Resources.InvalidMoveMessage);
                        break;
                }
            }
        }

        private bool IsInvalidKey(ConsoleKey key) => !_validKeys.Contains(key);

        private bool ShouldExit(ConsoleKeyInfo key) => key.Key == ConsoleKey.E;
    }
}