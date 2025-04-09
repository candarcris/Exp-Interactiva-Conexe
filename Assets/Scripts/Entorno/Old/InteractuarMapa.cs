using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarMapa : MonoBehaviour
{
    public GameObject mapa;

    public GameObject fadeObjetos;
    public GameObject mouse;
    public GameObject vfxAura;
    
    public void OnLookEnter()
    {

        mapa.SetActive(true);
        fadeObjetos.SetActive(true);
        SetPauseGame(true);
        
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
