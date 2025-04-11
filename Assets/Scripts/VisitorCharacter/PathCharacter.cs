using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCharacter : MonoBehaviour
{
    private float velocidad = 1;
    [SerializeField] private Transform puntoRutaActual;
    [SerializeField] private PuntoDeRuta puntoSeleccionado;

    public List<Transform> guiasRuta = new();
    public bool enPosicion = false;
    public bool observar = false;
    public bool enfocar = false;
    public GameObject camara;
    private MouseLookController _mouseLookController;
    private Transform objetivoActual;

    private void Awake()
    {
        _mouseLookController = camara.GetComponent<MouseLookController>();
    }

    void FixedUpdate()
    {
        Observacion();
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
                observar = true;
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
        observar = false;
    }

    void Observacion()
    {
        if(observar == true)
        {
            _mouseLookController.ActivarMouseLook();
        }
    }

    public void SetEnfoque(Transform objetivo)
    {
        objetivoActual = objetivo;
        enfocar = true;
    }

    public void CancelarEnfoque()
    {
        objetivoActual = null;
        enfocar = false;
    }
}
