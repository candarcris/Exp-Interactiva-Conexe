using UnityEngine;
using UnityEngine.ProBuilder;

public class EventoRevisarCredenciales : IEvent
{
    private GameObject _registroLoginPanel;
    private GameObject _fade;

    public EventoRevisarCredenciales(GameObject registroLoginPanel, GameObject fade) 
    {
        _registroLoginPanel = registroLoginPanel;
        _fade = fade;
    }
    public string ID => "Lobby_RevisarCredenciales";

    public void Ejecutar()
    {
        _registroLoginPanel.SetActive(true);
        _fade.SetActive(true);
        ManagerLocator.Instance.Get<IPathCharacter>().PoderObservar(false);
        DialogoUI.Instance.FinalizarDialogo();
        MouseState.Instance.LockCursor(false);
    }
}
