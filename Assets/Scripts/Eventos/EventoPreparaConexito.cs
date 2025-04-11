using UnityEngine;

public class EventoPreparaConexito : IEvent
{
    private Animator _recepcionista;
    private GameObject _efectoConexito;
    private Camera _camara;
    private Transform _conexitoTransform;
    private PathCharacter _character;

    public EventoPreparaConexito(Animator recepcionista, GameObject efectoConexito, Camera camara, Transform conexitoTransform, PathCharacter character) 
    { 
        _recepcionista = recepcionista;
        _efectoConexito = efectoConexito;
        _camara = camara;
        _conexitoTransform = conexitoTransform;
        _character = character;
    }
    public string ID => "Lobby_PreparaConexito";

    public void Ejecutar()
    {
        _recepcionista.SetTrigger("Idle");
        _efectoConexito.SetActive(true);
        _character.SetEnfoque(_conexitoTransform);
    }
}
