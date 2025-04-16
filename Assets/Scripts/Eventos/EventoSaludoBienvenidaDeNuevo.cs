using UnityEngine;
using UnityEngine.TextCore.Text;

public class EventoSaludoBienvenidaDeNuevo : MonoBehaviour, IEvent
{
    private readonly ConexitoController _conexitoController;
    private GameObject _efectoConexito;
    private PathCharacter _character;
    private Transform _conexito;

    public EventoSaludoBienvenidaDeNuevo(ConexitoController conexitoController, GameObject efectoConexito, PathCharacter character, Transform conexito)
    {
        _conexitoController = conexitoController;
        _efectoConexito = efectoConexito;
        _character = character;
        _conexito = conexito;
    }

    public string ID => "Lobby_DeNuevoRecibeLentes";

    public void Ejecutar()
    {
        _character.SetEnfoque(_conexito);
        _conexito.gameObject.SetActive(true);
        _conexitoController.EntregarGafas();
    }
}
