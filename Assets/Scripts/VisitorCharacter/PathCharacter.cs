using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCharacter : MonoBehaviour, IPathCharacter
{
    private float velocidad = 1;
    [SerializeField] private Transform puntoRutaActual;
    [SerializeField] private PuntoDeRuta puntoSeleccionado;

    public List<Transform> guiasRuta = new();
    public bool enPosicion = false;
    public bool enfocar = false;
    public GameObject camara;
    private MouseLookController _mouseLookController;
    private Transform objetivoActual;

    private void Awake()
    {
        _mouseLookController = camara.GetComponent<MouseLookController>();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        PoderObservar(false);
    }

    void FixedUpdate()
    {
        if (!enPosicion && puntoRutaActual != null)
        {
            Desplazamiento(puntoRutaActual);
        }
        if (enfocar && objetivoActual != null)
        {
            camara.transform.LookAt(objetivoActual.position);
        }
    }

    void Desplazamiento(Transform puntoRuta)
    {
        float velocidadDesplazamiento = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, puntoRuta.position, velocidadDesplazamiento);

        if (Vector3.Distance(transform.position, puntoRuta.position) < 0.1f)
        {
            enPosicion = true;
            puntoSeleccionado.dialogoTrigger?.EjecutarDialogo();
            if (puntoSeleccionado != null && puntoSeleccionado.activarObservacion)
            {
                PoderObservar(true);
            }

            puntoRutaActual = null;
            puntoSeleccionado = null;
        }
    }

    public void MoverAPunto(PuntoDeRuta punto)
    {
        puntoRutaActual = punto.transform;
        puntoSeleccionado = punto;

        enPosicion = false;
    }

    public void SetEnfoque(Transform objetivo)
    {
        PoderObservar(false);
        objetivoActual = objetivo;
        enfocar = true;
    }

    public void CancelarEnfoque()
    {
        PoderObservar(true);
        objetivoActual = null;
        enfocar = false;
    }

    public void PoderObservar(bool value)
    {
        if (value)
        {
            _mouseLookController.ActivarObservacion();
        }
        else
        {
            _mouseLookController.DesactivarObservacion();
        }
    }
}
