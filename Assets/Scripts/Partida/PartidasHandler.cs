using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

// Tipos json ------------------------

[System.Serializable]
public class Partida {
  public string nombre;
  public string fecha;
  public string nivel;
}

[System.Serializable]
public class Partidas {
  public Partida[] partidas;
}

// ----------------------------------

public class PartidasHandler : MonoBehaviour {
  [SerializeField]
  GameObject partidasPopup;

  // lista de partidas
  private Partidas partidas;
  private string jsonFilePath;

  public void Start() {
    jsonFilePath =
        Path.Combine(Application.persistentDataPath, "partidas.json");
    CrearInstancias();
  }

  private void CrearInstancias() {
    // get body game object in partidasPopup and then his child PartidasLayout
    GameObject partidasLayout = partidasPopup.transform.Find("Body")
                                    .transform.Find("PartidasLayout")
                                    .gameObject;
    CargarInstanciasPartidas(partidasLayout);
  }

  private void CreateInstance(GameObject partidasLayout, Partida partida) {
    GameObject partidaInstance = InstantiatePartida();
    updateInstanceValues(partidaInstance, partida);
    SetParent(partidaInstance, partidasLayout);
  }

  private void CargarInstanciasPartidas(GameObject partidasLayout) {
    string jsonFile = readJsonFile(jsonFilePath);
    partidas = parseJsonText(jsonFile);
    foreach (var partida in partidas.partidas) {
      CreateInstance(partidasLayout, partida);
    }
  }

  // lee de carpeta Resources archivo json
  private string readJsonFile(string fileName) {
    if (!File.Exists(jsonFilePath)) {
      File.Create(jsonFilePath).Dispose();
      File.WriteAllText(jsonFilePath, "{\"partidas\":[]}");
    }
    return File.ReadAllText(jsonFilePath);
  }

  private void savePartidasToFile(string jsonFilePath) {
    string json = JsonUtility.ToJson(partidas, true);
    Debug.Log(json);
    File.WriteAllText(jsonFilePath, json);
  }

  // parse json file to Partidas object
  private Partidas parseJsonText(string jsonContent) {
    return JsonUtility.FromJson<Partidas>(jsonContent);
  }

  private GameObject InstantiatePartida() {
    return Instantiate(Resources.Load("Partida", typeof(GameObject)))
        as GameObject;
  }

  private void updateInstanceValues(GameObject partidaInstance,
                                    Partida session) {
    partidaInstance.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
        () => {
          // load the game scene
          SceneManager.LoadScene("Nivel" + session.nivel);
          Time.timeScale = 1;
        });

    partidaInstance.transform.Find("PanelPartida")
        .transform.Find("Panel")
        .transform.Find("ButtonDeletePartida")
        .GetComponent<UnityEngine.UI.Button>()
        .onClick.AddListener(() => {
          // delete partida
          List<Partida> partidaList = new List<Partida>(partidas.partidas);
          partidaList.Remove(session);
          partidas.partidas = partidaList.ToArray();
          savePartidasToFile(jsonFilePath);
          Destroy(partidaInstance);
        });
    partidaInstance.transform.Find("PanelPartida")
        .transform.Find("Valores")
        .transform.Find("tituloPartida")
        .GetComponent<TMPro.TextMeshProUGUI>()
        .text = session.nombre;
    partidaInstance.transform.Find("PanelPartida")
        .transform.Find("Valores")
        .transform.Find("fechaPartida")
        .GetComponent<TMPro.TextMeshProUGUI>()
        .text = session.fecha;
    partidaInstance.transform.Find("PanelPartida")
        .transform.Find("Valores")
        .transform.Find("nivelPartida")
        .GetComponent<TMPro.TextMeshProUGUI>()
        .text += session.nivel;
  }

  private void SetParent(GameObject child, GameObject parent) {
    child.transform.SetParent(parent.transform, false);
  }

  public void MostrarInputNombrePartida() {
    partidasPopup.transform.Find("InputNombrePartida")
        .transform.Find("InputField")
        .GetComponent<TMPro.TMP_InputField>()
        .text = "";
    partidasPopup.transform.Find("InputNombrePartida")
        .gameObject.SetActive(true);
  }

  public void OcultarInputNombrePartida() {
    partidasPopup.transform.Find("InputNombrePartida")
        .transform.Find("InputField")
        .GetComponent<TMPro.TMP_InputField>()
        .text = "";
    partidasPopup.transform.Find("InputNombrePartida")
        .gameObject.SetActive(false);
  }

  public void CrearPartida() {
    List<Partida> partidaList = new List<Partida>(partidas.partidas);
    string nombrePartida = partidasPopup.transform.Find("InputNombrePartida")
                               .transform.Find("InputField")
                               .GetComponent<TMPro.TMP_InputField>()
                               .text;

    // if length < 3
    if (partidaList.Count < 3 && nombrePartida.Length != 0) {
      Partida newPartida =
          new Partida { nombre = nombrePartida,
                        fecha = DateTime.Now.ToString("dd-MM-yyyy"),
                        nivel = "1" };
      partidaList.Add(newPartida);
      partidas.partidas = partidaList.ToArray();
      savePartidasToFile(jsonFilePath);
      CreateInstance(partidasPopup.transform.Find("Body")
                         .transform.Find("PartidasLayout")
                         .gameObject,
                     newPartida);
    }
    OcultarInputNombrePartida();
  }
}
