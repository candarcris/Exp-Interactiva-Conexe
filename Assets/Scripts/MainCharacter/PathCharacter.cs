using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCharacter : MonoBehaviour
{
    public float velocidad;

    public List<Transform> guiasRuta = new();
    public Transform guiaPersonaje;
    public Transform guiaLabPersonaje;
    public Transform guiaOficePersonaje;
    public bool enPosicion = false;
    public bool irLab = false;
    public bool irOfice = false;
    public bool observar = false;
    public GameObject camara;

    private void Start()
    {
        velocidad = 1;
    }

    void FixedUpdate()
    {
        Observacion();
        Desplazamiento();
        DesplazamientoLab();
        DesplazamientoOfice();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PuntoDeRuta")
        {
            enPosicion = true;
            observar = true;
            
            if(guiaPersonaje.GetComponent<Collider>())
            {
                guiaPersonaje.GetComponent<Collider>().enabled = false;
            }
        }
    }

    void Desplazamiento()
    {
        if(enPosicion == false)
        {
            float velocidadDesplazamiento = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, guiaPersonaje.position, velocidadDesplazamiento);
        }
    }

    void DesplazamientoLab()
    {
        if(irLab == true)
        {
            float velocidadDesplazamiento = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, guiaLabPersonaje.transform.position, velocidadDesplazamiento);
            observar = false;
        }
        
    }

    void DesplazamientoOfice()
    {
        if(irOfice == true)
        {
            float velocidadDesplazamiento = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, guiaOficePersonaje.transform.position, velocidadDesplazamiento);
            observar = false;
        }
    }

    void Observacion()
    {
        if(observar == true)
        {
            camara.GetComponent<MouseLook>().ActivarMouseLook();
        }
    }
}
