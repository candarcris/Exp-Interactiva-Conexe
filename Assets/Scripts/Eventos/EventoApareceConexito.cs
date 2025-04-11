using UnityEngine;

public class EventoApareceConexito : IEvent
{
    private ConexitoController _conexitoController;
    private Transform _conexito;
    private Transform _guiaGafasTransform;
    private GameObject _efectoConexito;
    public EventoApareceConexito(ConexitoController conexitoController, Transform conexito, Transform guiaGafasTransform, GameObject efectoConexito)
    {
        _conexitoController = conexitoController;
        _conexito = conexito;
        _guiaGafasTransform = guiaGafasTransform;
        _efectoConexito = efectoConexito;
    }
    public string ID => "Lobby_ApareceConexito";

    public void Ejecutar()
    {
        _conexito.gameObject.SetActive(true);
        _conexitoController.MirarHacia(_guiaGafasTransform);
        _efectoConexito.SetActive(false);
    }
}
