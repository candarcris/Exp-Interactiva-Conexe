using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    [SerializeField] private DialogoUI dialogosUI;

    //personajes2D y props
    public Conexito _conexito;
    public SelectionManager _selectionManager;
    public Animator _recepcionistaLu;
    private Animator _conexitoAnim;
    public Animator _cientificoCris;
    public Animator _cientificoNico;
    public Animator _oficinaAlo;
    public GameObject _gafas;

    //Efectos
    public Camera _camara;
    public GameObject _luzCegadoraEfecto;
    public GameObject _efectoConexito;

    //Componentes y fisicas
    public Transform _guiaConexitoGafas;
    private float _velocidadConexito = 2;

    //Booleanos de activación
    bool _mirarHaciaConexito;
    bool _mirarHaciaRecepcionista;
    bool ponerGafas;

    private void Awake()
    {
        dialogosUI = FindFirstObjectByType<DialogoUI>();
        _conexitoAnim = _conexito.GetComponent<Animator>();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // evita duplicados
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EjecutarEvento(string idEvento)
    {
        switch (idEvento)
        {
            case "SaludoBienvenida":
                _recepcionistaLu.SetTrigger("Saludo");
                break;

            case "PreparaConexito":
                _mirarHaciaConexito = true;
                _recepcionistaLu.SetTrigger("Idle");
                _efectoConexito.SetActive(true);
                break;

            case "ApareceConexito":
                _conexitoAnim.gameObject.SetActive(true);
                _conexitoAnim.transform.LookAt(_guiaConexitoGafas.transform.position);
                _efectoConexito.SetActive(false);
                break;

            case "RecibirLentes":
                _gafas.SetActive(true);
                _conexitoAnim.SetTrigger("EntregaGafas");
                ponerGafas = true;
                break;

            default:
                Debug.LogWarning("Evento no reconocido: " + idEvento);
                break;
        }
    }

    void MirarAlObjetivo()
    {
        if (_mirarHaciaConexito == true)
        {
            _camara.transform.LookAt(_conexitoAnim.transform.position);
        }
    }

    void ConexitoPoneGafas()
    {
        if (ponerGafas == true)
        {
            float velocidadmovconexito = _velocidadConexito * Time.deltaTime;
            _conexitoAnim.transform.position = Vector3.MoveTowards(_conexitoAnim.transform.position, _guiaConexitoGafas.transform.position, velocidadmovconexito);
            if (_conexito.gafasEntregadas)
            {
                _luzCegadoraEfecto.SetActive(true);
                _conexito.gameObject.SetActive(false);
                _mirarHaciaConexito = false;
                dialogosUI.FinalizarDialogo();
                _selectionManager.enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        MirarAlObjetivo();
        ConexitoPoneGafas();
    }
}
