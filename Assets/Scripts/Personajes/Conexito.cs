using UnityEngine;
using System;

public class Conexito : MainPersonaje
{
    public bool GafasEntregadas { get; private set; }

    public event Action OnGafasEntregadas;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GafasEntregadas)
        {
            GafasEntregadas = true;
            OnGafasEntregadas?.Invoke(); // Avisamos que se entregaron las gafas
        }
    }
}
