using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMainMenu : MonoBehaviour
{
  public void ExitToMenu()
  {
	UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
  }
}
