using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour, IEventSystem
{
    private static EventSystem _instance;
    private Dictionary<string, IEvent> _eventos = new();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RegistrarEvento(IEvent ejecutable)
    {
        if (!_eventos.ContainsKey(ejecutable.ID))
            _eventos.Add(ejecutable.ID, ejecutable);
        else
            Debug.LogWarning($"Evento duplicado: {ejecutable.ID}");
    }

    public void EjecutarEvento(string idEvento)
    {
        if (_eventos.TryGetValue(idEvento, out var evento))
        {
            evento.Ejecutar();
        }
        else
        {
            Debug.LogWarning($"Evento no encontrado: {idEvento}");
        }
    }
}
