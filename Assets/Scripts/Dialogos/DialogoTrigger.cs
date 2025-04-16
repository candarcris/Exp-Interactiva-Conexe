using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogoTrigger : MonoBehaviour
{
    [SerializeField] private Dialogo dialogo; 
    public bool activarDialogo;


    public void EjecutarDialogo()
    {
        if (activarDialogo)
        {
            DialogoUI.Instance.IniciarDialogo(dialogo);
        }
    }
}
