using UnityEngine;

public interface IEventSystem
{
    void EjecutarEvento(string idEvento);
    void RegistrarEvento(IEvent ejecutable);
}
