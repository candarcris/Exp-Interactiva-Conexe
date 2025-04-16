using UnityEngine;
using System;

public class Conexito : MainPersonaje
{
    public bool GafasEntregadas { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GafasEntregadas)
        {
            GafasEntregadas = true;
            ManagerLocator.Instance.Get<IInteractiveEventManager>()?.DispararGafasEntregadas();
            Debug.Log("¡Gafas entregadas!");
        }
    }
}
