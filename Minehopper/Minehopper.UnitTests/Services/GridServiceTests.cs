using System;
using Minehopper.Configs;
using Minehopper.Enums;
using Minehopper.Interfaces;
using Minehopper.Models;
using Minehopper.Services;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Minehopper.UnitTests.Services;

[TestFixture]
public class GridServiceTests
{
    [TestCase("A1")]
    [TestCase("B2")]
    [TestCase("C3")]
    public void GetPlayerPosition_EqualsTestValue(string expectedPlayerPosition)
    {
        // Arrange
        var mocker = new AutoMocker();
        var navigationServiceMock = mocker.GetMock<IGridNavigationService>();
        navigationServiceMock.Setup(x => x.GetPlayerPosition()).Returns(expectedPlayerPosition);
        var gridCreationServiceMock = mocker.GetMock<IGridCreationService>();
        var gridService = new GridService(new DefaultConfig(), navigationServiceMock.Object,
            gridCreationServiceMock.Object);

        // Act
        var actualPlayerPosition = gridService.GetPlayerPosition();

        // Assert
        Assert.AreEqual(expectedPlayerPosition, actualPlayerPosition);
    }

    [TestCase(ConsoleKey.UpArrow, MoveResult.Finished)]
    [TestCase(ConsoleKey.DownArrow, MoveResult.Moved)]
    [TestCase(ConsoleKey.LeftArrow, MoveResult.HitMineAndFinished)]
    [TestCase(ConsoleKey.RightArrow, MoveResult.UnableToMove)]
    public void Move_TestCaseKey_TestCaseMoveResult(ConsoleKey key, MoveResult expectedMoveResult)
    {
        // Arrange
        var mocker = new AutoMocker();
        var navigationServiceMock = mocker.GetMock<IGridNavigationService>();
        navigationServiceMock.Setup(x => x.Move(key, It.IsAny<Square[,]>())).Returns(expectedMoveResult);
        var gridCreationServiceMock = mocker.GetMock<IGridCreationService>();
        var gridService = new GridService(new DefaultConfig(), navigationServiceMock.Object,
            gridCreationServiceMock.Object);
        
        // Act
        var actualMoveResult = gridService.Move(key);
        
        // Assert
        Assert.AreEqual(expectedMoveResult, actualMoveResult);
    }
}