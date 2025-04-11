using UnityEngine;

public class EventLoader : MonoBehaviour
{
    public EventSystem _eventSystem;
    public Animator recepcionista;
    public GameObject efectoConexito;
    public GameObject conexito;
    public Camera _camera;
    public Transform _guiaGafas;
    public PathCharacter _character;
    private ConexitoController _conexitoController;

    private void Awake()
    {
        _conexitoController = conexito.GetComponent<ConexitoController>();
    }

    private void Start()
    {
        // ManagerLocator.Instance.Register<IEventSystem>(this);
        recepcionista.GetComponent<Animator>();
        _eventSystem.RegistrarEvento(new EventoSaludoBienvenida(recepcionista));
        _eventSystem.RegistrarEvento(new EventoPreparaConexito(recepcionista, efectoConexito, _camera, conexito.transform, _character));
        _eventSystem.RegistrarEvento(new EventoApareceConexito(_conexitoController, conexito.transform, _guiaGafas, efectoConexito));
        _eventSystem.RegistrarEvento(new EventoRecibirLentes(_conexitoController));
    }
}
