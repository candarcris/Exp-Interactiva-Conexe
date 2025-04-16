using UnityEngine;
using System;

public interface IInteractiveEventManager
{
    event Action OnGafasEntregadas;
    void DispararGafasEntregadas();
}
