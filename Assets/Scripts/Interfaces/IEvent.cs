using UnityEngine;

public interface IEvent
{
    string ID { get; }
    void Ejecutar();
}
