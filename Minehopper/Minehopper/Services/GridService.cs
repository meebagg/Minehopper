using Minehopper.Enums;
using Minehopper.Interfaces;
using Minehopper.Models;

namespace Minehopper.Services;
/// <summary>
/// This class maintains the grid state, as well as forwarding movement calls to the dedicated navigation service.  
/// </summary>
public class GridService : IGridService
{
    private readonly Square[,] _squares;
    private readonly IGridNavigationService _navigationService;

    public GridService(IConfig config, IGridNavigationService navigationService, IGridCreationService gridCreationService)
    {
        // If too many mines for the specified dimensions, throw an exception
        if (config.NumberOfMines >= config.GridWidth * config.GridHeight)
        {
            throw new ArgumentOutOfRangeException(
                "Number of mines must be equal to at most the number of squares minus one");
        }
        
        _navigationService = navigationService;

        // Populate and obtain start location
        var result = gridCreationService.Create(config.GridWidth, config.GridHeight, config.NumberOfMines);

        // Keep a reference to the newly created grid
        _squares = result.squares;
        
        // Set the start position in the dedicated navigation service
        _navigationService.SetPlayerPosition(result.startX, result.startY);
    }

    /// <summary>
    /// Get location in chess location notation.  
    /// </summary>
    /// <returns></returns>
    public string GetPlayerPosition() => _navigationService.GetPlayerPosition();
    
    /// <summary>
    /// Pass on move request to navigation service.  
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public MoveResult Move(ConsoleKey key) => _navigationService.Move(key, _squares);
}