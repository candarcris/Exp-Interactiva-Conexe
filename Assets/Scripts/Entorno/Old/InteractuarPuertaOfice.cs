using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarPuertaOfice : MonoBehaviour
{
    public PathCharacter personaje;    
    public GameObject vfxAura;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnLookEnter()
    {
        animator.SetTrigger("AbrirOfice");
        personaje.irOfice = true;
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
