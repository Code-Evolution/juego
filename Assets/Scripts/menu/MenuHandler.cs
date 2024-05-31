using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
  [SerializeField] private GameObject mainMenu;
  [SerializeField] private GameObject settingsMenu;
  public void ToggleSettings()
  {
	mainMenu.SetActive(!mainMenu.activeSelf);
	settingsMenu.SetActive(!settingsMenu.activeSelf);
  }
}
