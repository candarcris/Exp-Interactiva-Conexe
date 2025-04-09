using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarCuadroHonor : MonoBehaviour
{
    public GameObject insignia;
    public GameObject aceptar;
    public GameObject fadeObjetos;
    public GameObject titulo;
    public GameObject mouse;
    public GameObject camara;
    public GameObject vfxAura;
    private GameObject objetivo;

    private void Awake() 
    {
        objetivo = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void OnLookEnter()
    {

        insignia.SetActive(true);
        aceptar.SetActive(true);
        fadeObjetos.SetActive(true);
        titulo.SetActive(true);
        SetPauseGame(true);
        
    }

    public void SetPauseGame(bool pause)
    {
        if(pause == true)
        {
            //Time.timeScale = 0;

            if(mouse.GetComponent<MouseState>() != null)
            {
                mouse.GetComponent<MouseState>().OnApplicationFocus(false);
                MouseLook.speed = 0;
            }
        }
        else if(pause == false)
        {
            //Time.timeScale = 1;

            if(mouse.GetComponent<MouseState>() != null)
            {
                mouse.GetComponent<MouseState>().OnApplicationFocus(true);
                MouseLook.speed = 5;
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
