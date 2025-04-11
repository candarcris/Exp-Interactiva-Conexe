using UnityEngine;

public class EventoRecibirLentes : IEvent
{
    private readonly ConexitoController _conexitoController;
    private GameObject _gafas;
    private Animator _conexitoAnim;

    public EventoRecibirLentes(ConexitoController conexitoController)
    {
        _conexitoController = conexitoController;
    }
    public string ID => "Lobby_RecibirLentes";

    public void Ejecutar()
    {
        _conexitoController.EntregarGafas();
    }
}
