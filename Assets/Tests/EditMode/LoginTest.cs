using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;


public class NewMonoBehaviourTests
{
    public GameObject gameObject;
    public NewMonoBehaviour newMonoBehaviour;
    public InputField usernameField;
    public InputField passwordField;
    public Button loginButton;
    public Text resultText;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        newMonoBehaviour = gameObject.AddComponent<NewMonoBehaviour>();

        usernameField = new GameObject().AddComponent<InputField>();
        passwordField = new GameObject().AddComponent<InputField>();
        loginButton = new GameObject().AddComponent<Button>();
        resultText = new GameObject().AddComponent<Text>();

        newMonoBehaviour.usernameField = usernameField;
        newMonoBehaviour.passwordField = passwordField;
        newMonoBehaviour.loginButton = loginButton;
        newMonoBehaviour.resultText = resultText;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
        Object.DestroyImmediate(usernameField.gameObject);
        Object.DestroyImmediate(passwordField.gameObject);
        Object.DestroyImmediate(loginButton.gameObject);
        Object.DestroyImmediate(resultText.gameObject);
    }

    // Test 1: Verificar que los campos de texto no son nulos
    [Test]
    public void FieldsAreNotNull()
    {
        Assert.IsNotNull(newMonoBehaviour.usernameField);
        Assert.IsNotNull(newMonoBehaviour.passwordField);
        Assert.IsNotNull(newMonoBehaviour.loginButton);
        Assert.IsNotNull(newMonoBehaviour.resultText);
    }

    // Test 2: Verificar que se puede llamar a OnLoginButtonClicked sin errores
    [Test]
    public void OnLoginButtonClicked_DoesNotThrow()
    {
        usernameField.text = "testuser";
        passwordField.text = "testpassword";

        Assert.DoesNotThrow(() => newMonoBehaviour.OnLoginButtonClicked());
    }
    /*
    // Test 3: Verificar que al iniciar la escena, se añade el listener al botón de login
    [Test]
    public void Start_AddsLoginButtonListener()
    {
        var initialListeners = loginButton.onClick.GetPersistentEventCount();
        newMonoBehaviour.Start();
        var newListeners = loginButton.onClick.GetPersistentEventCount();

        Assert.Greater(newListeners, initialListeners);
    }

    // Test 4: Verificar que el mensaje de resultado se actualiza correctamente en caso de error
    [UnityTest]
    public IEnumerator Login_SetsResultText_OnConnectionError()
    {
        usernameField.text = "testuser";
        passwordField.text = "testpassword";

        newMonoBehaviour.loginUrl = "http://invalid_url"; // Simulamos una URL inválida para forzar un error de conexión

        newMonoBehaviour.OnLoginButtonClicked();
        yield return new WaitForSeconds(1f);

        Assert.IsTrue(newMonoBehaviour.resultText.text.StartsWith("Error:"));
    }
    */
}

