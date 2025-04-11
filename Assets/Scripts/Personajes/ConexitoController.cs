using UnityEngine;
using UnityEngine.TextCore.Text;

public class ConexitoController : MonoBehaviour
{
    [SerializeField] private Conexito _conexito;
    [SerializeField] private GameObject _efectoConexito;
    [SerializeField] private GameObject _gafas;
    [SerializeField] private GameObject _luzCegadoraEfecto;
    [SerializeField] private Transform _guiaGafas;
    [SerializeField] private PathCharacter _character;

    private bool _moverConexito = false;
    private float _velocidad = 2f;

    private void Start()
    {
        _conexito.OnGafasEntregadas += EntregarGafas;
    }

    private void FixedUpdate()
    {
        if (_moverConexito)
        {
            MoverConexitoHaciaPunto();
        }
    }

    public void EntregarGafas()
    {
        _gafas.SetActive(true);
        _conexito.Animator.SetTrigger("EntregaGafas");
        _moverConexito = true;
    }

    public void MirarHacia(Transform objetivo)
    {
        if (objetivo == null) return;

        Vector3 direccion = objetivo.position - transform.position;
        direccion.y = 0f; // Opcional: evita que se incline verticalmente
        if (direccion != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direccion);
    }

    private void MoverConexitoHaciaPunto()
    {
        var t = _conexito.transform;
        t.position = Vector3.MoveTowards(t.position, _guiaGafas.position, _velocidad * Time.deltaTime);

        if (Vector3.Distance(t.position, _guiaGafas.position) < 0.1f)
        {
            _moverConexito = false;
            _luzCegadoraEfecto.SetActive(true);
            _conexito.gameObject.SetActive(false);
            _character.CancelarEnfoque();
            DialogoUI.Instance.FinalizarDialogo();
        }
    }
}
