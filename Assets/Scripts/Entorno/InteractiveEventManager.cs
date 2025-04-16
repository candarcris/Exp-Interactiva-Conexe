using System;
using UnityEngine;

public class InteractiveEventManager : MonoBehaviour, IInteractiveEventManager
{
    public event Action OnGafasEntregadas;

    public void DispararGafasEntregadas()
    {
        OnGafasEntregadas?.Invoke();
    }
}
