using System;
using Minehopper.Configs;
using Minehopper.Models;
using Minehopper.Services;
using NUnit.Framework;

namespace Minehopper.UnitTests.Services;

[TestFixture]
public class GridNavigationServiceTests
{
    [Test]
    public void GetPlayerPosition_AfterSetPlayerPosition_SameValues()
    {
        // Arrange
        var navigationService = new GridNavigationService(new ConfigBase(4, 4, 2, 3));
        navigationService.SetPlayerPosition(0, 3);
        
        // Act
        string currentPosition = navigationService.GetPlayerPosition();
        
        // Assert
        Assert.AreEqual("A1", currentPosition);
    }
    
    [Test]
    public void GetPlayerPosition_BeforeSetPlayerPosition_ThrowsException()
    {
        // Arrange
        var navigationService = new GridNavigationService(new ConfigBase(4, 4, 2, 3));

        // Act/Assert
        Assert.Throws<InvalidOperationException>(() => navigationService.GetPlayerPosition());
    }
    
    [Test]
    public void Move_BeforeSetPlayerPosition_ThrowsException()
    {
        // Arrange
        var navigationService = new GridNavigationService(new ConfigBase(4, 4, 2, 3));

        // Act/Assert
        Assert.Throws<InvalidOperationException>(() => navigationService.Move(ConsoleKey.UpArrow, new Square[1,1]));
    }

    [TestCase(ConsoleKey.UpArrow, "B3")]
    [TestCase(ConsoleKey.DownArrow, "B1")]
    [TestCase(ConsoleKey.LeftArrow, "A2")]
    [TestCase(ConsoleKey.RightArrow, "C2")]
    public void Move_Direction_CurrentPositionMovedToDirection(ConsoleKey key, string expectedPlayerPosition)
    {
        // Arrange
        var navigationService = new GridNavigationService(new ConfigBase(3, 3, 0, 3));
        var squares = GetSquares(3, 3);
        navigationService.SetPlayerPosition(1, 1);

        // Act
        navigationService.Move(key, squares);
        var playerPosition = navigationService.GetPlayerPosition();

        // Assert
        Assert.AreEqual(expectedPlayerPosition, playerPosition);
    }

    private Square[,] GetSquares(int width, int height)
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

        return squares;
    }
}