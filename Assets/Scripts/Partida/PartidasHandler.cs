using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartidasHandler : MonoBehaviour
{
  [SerializeField] GameObject menu;
  [SerializeField] GameObject partidas;

  private bool partidasMenuActive = false;

  public void Start()
  {
	CrearInstancias();
  }

  public void TogglePartidasMenu()
  {
	partidasMenuActive = !partidasMenuActive;
	menu.SetActive(!menu.activeSelf);
	partidas.SetActive(!partidas.activeSelf);
  }

  private void CrearInstancias()
  {
	// add component CargoPartida
	CargarPartida cargarPartida = partidas.AddComponent<CargarPartida>();
	// get body game object in partidas and then his child PartidasLayout
	GameObject partidasLayout = partidas.transform.Find("Body").transform.Find("PartidasLayout").gameObject;
	cargarPartida.CargarInstanciasPartidas(partidasLayout);
  }
}
