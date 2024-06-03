using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class VolumeTest {private GameObject canvasObject;
    private GameObject gameObject;
    private VolumeHandler volumeHandler;
    private Slider slider;

    [SetUp]
    public void SetUp() {
        // Crear un Canvas para los elementos de UI
        canvasObject = new GameObject();
        canvasObject.AddComponent<Canvas>();
        canvasObject.AddComponent<CanvasScaler>();
        canvasObject.AddComponent<GraphicRaycaster>();

        // Crear un GameObject para el VolumeHandler
        gameObject = new GameObject();
        volumeHandler = gameObject.AddComponent<VolumeHandler>();
        
        // Crear un Slider y asignarlo al VolumeHandler
        GameObject sliderObject = new GameObject();
        sliderObject.transform.parent = canvasObject.transform;
        slider = sliderObject.AddComponent<Slider>();
        volumeHandler.audioSlider = slider;
    }

    [TearDown]
    public void TearDown() {
        // Eliminar los GameObjects después de cada prueba
        GameObject.DestroyImmediate(canvasObject);
        GameObject.DestroyImmediate(gameObject);
        PlayerPrefs.DeleteKey("Volume"); // Limpiar PlayerPrefs después de cada prueba
    }

    [UnityTest]
    public IEnumerator ChangeVolume_UpdatesAudioListenerVolume() {
        // Configurar el slider y cambiar el volumen
        slider.value = 0.5f;
        volumeHandler.ChangeVolume();

        // Esperar un frame para que se apliquen los cambios
        yield return null;

        // Verificar que el volumen de AudioListener se haya actualizado
        Assert.AreEqual(0.5f, AudioListener.volume, 0.01f);
    }

    [UnityTest]
    public IEnumerator Load_LoadsVolumeFromPlayerPrefs() {
        // Guardar un valor en PlayerPrefs
        PlayerPrefs.SetFloat("Volume", 0.75f);
        
        // Llamar al método Load
        volumeHandler.Load();

        // Esperar un frame para que se apliquen los cambios
        yield return null;

        // Verificar que el slider tenga el valor correcto
        Assert.AreEqual(0.75f, slider.value, 0.01f);
    }

    [UnityTest]
    public IEnumerator Save_SavesVolumeToPlayerPrefs() {
        // Configurar el slider y guardar el volumen
        slider.value = 0.3f;
        volumeHandler.Save();

        // Esperar un frame para que se apliquen los cambios
        yield return null;

        // Verificar que PlayerPrefs tenga el valor correcto
        Assert.AreEqual(0.3f, PlayerPrefs.GetFloat("Volume"), 0.01f);
  }
}
