using UnityEngine;

public class EventoSaludoBienvenida : IEvent
{
    private Animator _recepcionista;

    public EventoSaludoBienvenida(Animator recepcionista)
    {
        _recepcionista = recepcionista;
    }

    public string ID => "Lobby_SaludoBienvenida";

    public void Ejecutar()
    {
        _recepcionista.SetTrigger("Saludo");
    }
}
