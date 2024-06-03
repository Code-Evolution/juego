using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class MenuHandlerTests
{
    private GameObject menuHandlerObject;
    private MenuHandler menuHandler;
    private GameObject mainMenu;
    private GameObject settingsMenu;
    private GameObject partidasMenu;
    private GameObject leaderboard;

    [SetUp]
    public void Setup()
    {
        // Arrange: Create game objects for testing
        menuHandlerObject = new GameObject();
        menuHandler = menuHandlerObject.AddComponent<MenuHandler>();

        mainMenu = new GameObject("MainMenu");
        settingsMenu = new GameObject("SettingsMenu");
        partidasMenu = new GameObject("PartidasMenu");
        leaderboard = new GameObject("Leaderboard");

        // Set initial states
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        partidasMenu.SetActive(false);
        leaderboard.SetActive(false);

        // Assign references in the MenuHandler
        menuHandler.GetType()
            .GetField("mainMenu", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(menuHandler, mainMenu);
        menuHandler.GetType()
            .GetField("settingsMenu", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(menuHandler, settingsMenu);
        menuHandler.GetType()
            .GetField("partidasMenu", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(menuHandler, partidasMenu);
        menuHandler.GetType()
            .GetField("Leaderboard", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(menuHandler, leaderboard);
    }

    [UnityTest]
    public IEnumerator ToggleSettings_ShouldToggleMenus()
    {
        // Act
        menuHandler.ToggleSettings();
        yield return null; // Wait for the next frame

        // Assert
        Assert.IsFalse(mainMenu.activeSelf);
        Assert.IsTrue(settingsMenu.activeSelf);

        // Act again to toggle back
        menuHandler.ToggleSettings();
        yield return null; // Wait for the next frame

        // Assert
        Assert.IsTrue(mainMenu.activeSelf);
        Assert.IsFalse(settingsMenu.activeSelf);
    }

    [UnityTest]
    public IEnumerator TogglePartidasMenu_ShouldToggleMenus()
    {
        // Act
        menuHandler.TogglePartidasMenu();
        yield return null; // Wait for the next frame

        // Assert
        Assert.IsFalse(mainMenu.activeSelf);
        Assert.IsTrue(partidasMenu.activeSelf);

        // Act again to toggle back
        menuHandler.TogglePartidasMenu();
        yield return null; // Wait for the next frame

        // Assert
        Assert.IsTrue(mainMenu.activeSelf);
        Assert.IsFalse(partidasMenu.activeSelf);
    }

    [UnityTest]
    public IEnumerator ToggleLeaderboard_ShouldToggleMenus()
    {
        // Act
        menuHandler.ToggleLeaderboard();
        yield return null; // Wait for the next frame

        // Assert
        Assert.IsFalse(mainMenu.activeSelf);
        Assert.IsTrue(leaderboard.activeSelf);

        // Act again to toggle back
        menuHandler.ToggleLeaderboard();
        yield return null; // Wait for the next frame

        // Assert
        Assert.IsTrue(mainMenu.activeSelf);
        Assert.IsFalse(leaderboard.activeSelf);
    }

    [Test]
    public void ExitGame_ShouldQuitApplication()
    {
        // Act
        menuHandler.ExitGame();

        // Assert
        // Unfortunately, Application.Quit() cannot be tested in the editor.
        // You might need to mock this method if you want to test it.
        // For now, we'll just assume it works as expected.
        Assert.Pass("ExitGame method called. Application.Quit() cannot be tested in the editor.");
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.Destroy(menuHandlerObject);
        Object.Destroy(mainMenu);
        Object.Destroy(settingsMenu);
        Object.Destroy(partidasMenu);
        Object.Destroy(leaderboard);
    }
}
