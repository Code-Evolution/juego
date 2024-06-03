using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour {
  [SerializeField]
  public Slider audioSlider;
  // Start is called before the first frame update
  void Start() {
    if (!PlayerPrefs.HasKey("Volume")) {
      PlayerPrefs.SetFloat("Volume", 1);
    }
    Load();
  }

  public void ChangeVolume() {
    AudioListener.volume = audioSlider.value;
    Save();
  }

  public void Load() { audioSlider.value = PlayerPrefs.GetFloat("Volume"); }

  public void Save() { PlayerPrefs.SetFloat("Volume", audioSlider.value); }
}
