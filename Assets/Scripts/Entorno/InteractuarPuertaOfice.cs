using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarPuertaOfice : MonoBehaviour
{
    public GameObject personaje;    
    public GameObject vfxAura;
    public void OnLookEnter()
    {
        this.GetComponent<Animator>().SetTrigger("AbrirOfice");
        personaje.GetComponent<PathCharacter>().irOfice = true;
        ActivarAura(false);
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
