using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerScoreTests
{
    [Test]
    public void PlayerScore_Constructor_ShouldSetPlayerName()
    {
        // Arrange
        string expectedPlayerName = "Player1";
        int expectedScore = 100;

        // Act
        PlayerScore playerScore = new PlayerScore(expectedPlayerName, expectedScore);

        // Assert
        Assert.AreEqual(expectedPlayerName, playerScore.playerName);
    }

    [Test]
    public void PlayerScore_Constructor_ShouldSetScore()
    {
        // Arrange
        string expectedPlayerName = "Player1";
        int expectedScore = 100;

        // Act
        PlayerScore playerScore = new PlayerScore(expectedPlayerName, expectedScore);

        // Assert
        Assert.AreEqual(expectedScore, playerScore.score);
    }
}
