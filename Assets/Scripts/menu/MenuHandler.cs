using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour {
  [SerializeField]
  private GameObject mainMenu;
  [SerializeField]
  private GameObject settingsMenu;
  [SerializeField]
  private GameObject partidasMenu;

  public void ToggleSettings() {
    mainMenu.SetActive(!mainMenu.activeSelf);
    settingsMenu.SetActive(!settingsMenu.activeSelf);
  }

  public void TogglePartidasMenu() {
    mainMenu.SetActive(!mainMenu.activeSelf);
    partidasMenu.SetActive(!partidasMenu.activeSelf);
  }

  public void ExitGame() { Application.Quit(); }
}
