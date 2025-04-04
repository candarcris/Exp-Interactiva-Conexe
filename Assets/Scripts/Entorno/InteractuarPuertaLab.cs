using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarPuertaLab : MonoBehaviour
{
    public GameObject personaje;    
    public GameObject vfxAura;

    private void Awake()
    {
        
    }

    public void OnLookEnter()
    {
        this.GetComponent<Animator>().SetTrigger("AbrirLab");
        personaje.GetComponent<PathCharacter>().irLab = true;
        vfxAura.SetActive(false);
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
