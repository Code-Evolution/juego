using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitHubManager : MonoBehaviour
{
    public string gitHubUrl = "https://github.com/Code-Evolution/juego.git";

    public void OpenLink()
    {
        Application.OpenURL(gitHubUrl);
    }
}
