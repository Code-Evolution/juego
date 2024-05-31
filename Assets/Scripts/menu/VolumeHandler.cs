using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour
{
  [SerializeField] Slider audioSlider;
  // Start is called before the first frame update
  void Start()
  {
	if (!PlayerPrefs.HasKey("Volume"))
	{
	  PlayerPrefs.SetFloat("Volume", 1);
	}
	Load();
  }

  public void ChangeVolume()
  {
	AudioListener.volume = audioSlider.value;
	Save();
  }

  private void Load()
  {
	audioSlider.value = PlayerPrefs.GetFloat("Volume");
  }

  private void Save()
  {
	PlayerPrefs.SetFloat("Volume", audioSlider.value);
  }
}
