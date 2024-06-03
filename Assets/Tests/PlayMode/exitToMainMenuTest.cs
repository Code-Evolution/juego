using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


public class ExitToMainMenuTests
{
    [UnityTest]
    public IEnumerator ExitToMenu_ShouldLoadMenuScene()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        ExitToMainMenu exitToMainMenu = gameObject.AddComponent<ExitToMainMenu>();

        // Aquí creamos una escena temporal para simular la carga de la escena "Menu"
        SceneManager.CreateScene("Menu");

        // Act
        exitToMainMenu.ExitToMenu();
        yield return new WaitForSeconds(1f); // Espera un segundo para asegurar que la escena se carga

        // Assert
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

        // Limpia después de la prueba
        SceneManager.UnloadSceneAsync("Menu");
    }
}
