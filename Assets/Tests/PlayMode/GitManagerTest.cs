using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class GitHubManagerTests
{
    // Test 1: Verificar que el URL es correcto
    [Test]
    public void GitHubUrl_IsCorrect()
    {
        var gitHubManager = new GameObject().AddComponent<GitHubManager>();
        Assert.AreEqual("https://github.com/Code-Evolution/juego.git", gitHubManager.gitHubUrl);
    }

    // Test 2: Verificar que gitHubUrl no es nulo
    [Test]
    public void GitHubUrl_IsNotNull()
    {
        var gitHubManager = new GameObject().AddComponent<GitHubManager>();
        Assert.IsNotNull(gitHubManager.gitHubUrl);
    }

    // Test 3: Verificar que se puede llamar a OpenLink sin errores
    [Test]
    public void OpenLink_CallsApplicationOpenURL()
    {
        var gitHubManager = new GameObject().AddComponent<GitHubManager>();

        // No se puede verificar la llamada real a Application.OpenURL, pero podemos asegurarnos de que no lanza excepciones.
        Assert.DoesNotThrow(() => gitHubManager.OpenLink());
    }
}
