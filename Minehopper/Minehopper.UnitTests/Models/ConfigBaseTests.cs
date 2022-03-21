using Minehopper.Configs;
using NUnit.Framework;

namespace Minehopper.UnitTests.Models;

[TestFixture]
public class ConfigBaseTests
{
    [Test]
    public void GridWidth_Ten_Ten()
    {
        // Arrange
        int expectedValue = 10;
        var config = new ConfigBase(expectedValue, 1, 2, 3);
        
        // Assert
        Assert.AreEqual(expectedValue, config.GridWidth);
    }
    
    [Test]
    public void GridHeight_Ten_Ten()
    {
        // Arrange
        int expectedValue = 10;
        var config = new ConfigBase(1, expectedValue, 2, 3);
        
        // Assert
        Assert.AreEqual(expectedValue, config.GridHeight);
    }
    
    [Test]
    public void NumberOfMines_Ten_Ten()
    {
        // Arrange
        int expectedValue = 10;
        var config = new ConfigBase(20, 20, expectedValue, 3);
        
        // Assert
        Assert.AreEqual(expectedValue, config.NumberOfMines);
    }
    
    [Test]
    public void TotalLives_Ten_Ten()
    {
        // Arrange
        int expectedValue = 10;
        var config = new ConfigBase(20, 20, 20, expectedValue);
        
        // Assert
        Assert.AreEqual(expectedValue, config.TotalLives);
    }
}