using System.Linq;
using Minehopper.Models;
using Minehopper.Services;
using NUnit.Framework;

namespace Minehopper.UnitTests.Services;

[TestFixture]
public class GridCreationServiceTests
{
    [TestCase(10, 10)]
    [TestCase(10, 8)]
    [TestCase(10, 40)]
    [TestCase(10, 32)]
    public void Populate_EvenHeight_StartYIsHalfHeight(int width, int height)
    {
        // Arrange
        var service = new GridCreationService();
        
        // Act
        var startPosition = service.Create(width, height, 1);
        
        // Assert
        Assert.AreEqual(height / 2, startPosition.startY);
    }

    [TestCase(10, 11)]
    [TestCase(10, 9)]
    [TestCase(10, 41)]
    [TestCase(10, 33)]
    public void Populate_UnevenHeight_StartYIsMiddlePosition(int width, int height)
    {
        // Arrange
        var service = new GridCreationService();
        
        // Act
        var startPosition = service.Create(width, height, 1);
        
        // Assert
        Assert.AreEqual(height / 2 + 1, startPosition.startY);
    }

    [TestCase(10, 11, 3)]
    [TestCase(10, 9, 89)]
    [TestCase(10, 41, 17)]
    [TestCase(10, 33, 300)]
    public void Populate_MineCount_SquaresContainsMineCount(int width, int height, int expectedMineCount)
    {
        // Arrange
        var service = new GridCreationService();

        // Act
        var result = service.Create(width, height, expectedMineCount);
        var actualMineCount = result.squares.Cast<Square>().Count(x => x.IsMine);

        // Assert
        Assert.AreEqual(expectedMineCount, actualMineCount);
    }
}