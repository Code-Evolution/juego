using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CargarPartida : MonoBehaviour
{
  // Start is called before the first frame update
  // read from json file
  public void CargarInstanciasPartidas(GameObject partidasLayout)
  {

	// Deserialize JSON to GameSessionList object
	TextAsset jsonFile = Resources.Load<TextAsset>("partidas");

	GameSessionList sessionList = JsonUtility.FromJson<GameSessionList>(jsonFile.text);
	foreach (var session in sessionList.partidas)
	{
	  // create a new instance of the prefab
	  GameObject instance = Instantiate(Resources.Load("Partida", typeof(GameObject))) as GameObject;
	  instance.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
	  {
		// load the game scene
		SceneManager.LoadScene("Nivel" + session.nivel);
		Time.timeScale = 1;
	  });
	  instance.transform.Find("PanelPartida").transform.Find("tituloPartida").GetComponent<TMPro.TextMeshProUGUI>().text = session.nombre;
	  instance.transform.Find("PanelPartida").transform.Find("fechaPartida").GetComponent<TMPro.TextMeshProUGUI>().text = session.fecha;
	  instance.transform.Find("PanelPartida").transform.Find("nivelPartida").GetComponent<TMPro.TextMeshProUGUI>().text += session.nivel;

	  // add to parent
	  instance.transform.SetParent(partidasLayout.transform, false);
	}
  }
}

[System.Serializable]
public class GameSession
{
  public string nombre;
  public string fecha;
  public string nivel;
}

[System.Serializable]
public class GameSessionList
{
  public GameSession[] partidas;
}
