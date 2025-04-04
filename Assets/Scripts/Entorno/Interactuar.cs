using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactuar : MonoBehaviour
{
    public GameObject fadeObjetos;
    public GameObject info;
    public GameObject mouse;
    public GameObject vfxAura;
    
    public void OnLookEnter()
    {

        info.SetActive(true);
        fadeObjetos.SetActive(true);
        SetPauseGame(true);
        SelectionManager.pcElegido = true;
        
    }

    public void SetPauseGame(bool pause)
    {
        if(pause)
        {
            Time.timeScale = 0;

            if(mouse.GetComponent<MouseState>() != null)
            {
                mouse.GetComponent<MouseState>().OnApplicationFocus(false);
            }
        }
        else
        {
            Time.timeScale = 1;

            if(mouse.GetComponent<MouseState>() != null)
            {
                mouse.GetComponent<MouseState>().OnApplicationFocus(true);
            }
        }
    }

    public void ActivarAura(bool vfxActivado)
    {
        if(vfxActivado == true)
        {
            vfxAura.SetActive(true);
        }
        else if(vfxActivado == false)
        {
            vfxAura.SetActive(false);
        }
    }
}
