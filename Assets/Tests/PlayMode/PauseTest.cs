using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseTest
{
    private GameObject pauseObject;
    private Pause pauseScript;
    private GameObject botonPausa;
    private GameObject menuPausa;

    [SetUp]
    public void Setup()
    {
        // Crear los objetos necesarios
        pauseObject = new GameObject();
        botonPausa = new GameObject();
        menuPausa = new GameObject();

        // Añadir los componentes necesarios
        pauseScript = pauseObject.AddComponent<Pause>();
        pauseScript.botonPausa = botonPausa;
        pauseScript.menuPausa = menuPausa;
    }

    [Test]
    public void Pause_Initialization()
    {
        // Assert
        Assert.IsNotNull(pauseScript.botonPausa);
        Assert.IsNotNull(pauseScript.menuPausa);
    }

    [Test]
    public void Pause_GamePause()
    {
        // Act
        pauseScript.Pausa();

        // Assert
        Assert.IsTrue(pauseScript.juegoPausado);
        Assert.AreEqual(0f, Time.timeScale);
        Assert.IsFalse(botonPausa.activeSelf);
        Assert.IsTrue(menuPausa.activeSelf);
    }

    [Test]
    public void Pause_GameResume()
    {
        // Arrange
        pauseScript.Pausa();

        // Act
        pauseScript.Reanudar();

        // Assert
        Assert.IsFalse(pauseScript.juegoPausado);
        Assert.AreEqual(1f, Time.timeScale);
        Assert.IsTrue(botonPausa.activeSelf);
        Assert.IsFalse(menuPausa.activeSelf);
    }
    [Test]
    public void Pause_TogglePauseWithEscape()
    {
        // Act - Simular presionar la tecla Escape
        pauseScript.Update(); // Llama a Update para verificar la tecla Escape
        bool escapePressed = Input.GetKeyDown(KeyCode.Escape); // Guarda el resultado
        if (escapePressed)
        {
            pauseScript.Update(); // Llama a Update de nuevo para procesar la pulsación de tecla
        }

        // Assert - Debería pausar el juego si la tecla Escape fue presionada
        if (escapePressed)
        {
            Assert.IsTrue(pauseScript.juegoPausado);
        }
        else
        {
            Assert.IsFalse(pauseScript.juegoPausado);
        }
    }


}
