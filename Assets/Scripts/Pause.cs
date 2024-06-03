using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject botonPausa;
    [SerializeField] public GameObject menuPausa;
    public bool juegoPausado = false;

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(juegoPausado){
                Reanudar();
            }else{
                Pausa();
            }
        }
    }

    public void Pausa(){
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar(){
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
