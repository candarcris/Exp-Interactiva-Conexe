using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoEventos : MonoBehaviour
{
    public PlayFabManager playFabManager;
    public CharacterData characterData;
    public Text textElement;
    public Text textElement2;
    string textValue;
    string textValue2;
    string textValueC1;
    string textValueC2;
    string textValueC3;
    string textValueC4;
    public static string textValueC5;
    public GameObject fondoTextos;
    private Animator animConexito;
    float velocidadConexito = 2;
    public GameObject conexito;
    public GameObject gafasObj;
    public GameObject luzCegadoraEfecto;
    bool gafas = false;
    private SelectionManager interactividad;
    public GameObject guiaConexitoGafas;
    private Camera cam;
    bool mirar;
    bool mirarE;
    public GameObject efectoConexito;
    public Animator recepcionista;

    public GameObject botonModificar;
    

    private void Awake() 
    {
        textValue = "Hola, Bienvenido a Conexe, nos alegra \n la visita de alguien tan importante.";
        textValue2 = "Quiero presentarte a EX-E1, nuestro asistente virtual \n y tu compañero durante todo el recorrido...";
        textValueC1 = "Saludos, quiero comentarte que nuestra empresa es más \n de lo que hay a simple vista, en unos momentos lo entenderás.";
        textValueC2 = "Con estas GAFAS mejorará tu experiencia, ya verás.";
        textValueC3 = "Podrás ver un efecto sobre todos los objetos interactivos \n prueba hacer CLICK sobre cada uno.";
        textValueC4 = "Bueno, ahora que estás en nuestra base de datos, ya puedes explorar todo el lugar \n seleccionando cualquiera de las dos puertas.";
        animConexito = conexito.GetComponent<Animator>();
        interactividad = this.GetComponentInChildren<SelectionManager>();
        cam = GetComponentInChildren<Camera>();
        mirar = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PuntoDeRuta")
        {
            playFabManager.GetData();
            fondoTextos.SetActive(true);
            //StartCoroutine(Reloj());
        }

        if(other.tag == "Conexito")
        {
            conexito.SetActive(false);
            luzCegadoraEfecto.SetActive(true);
            interactividad.enabled = true;
            mirar = false;
            mirarE = false;
        }
    }

    private void Update() 
    {
        ConexitoPoneGafas();
        Registro();
        MirarEConexito();
        MirarConexito();
    }

    public void UsuarioRegistrado()
    {
        Debug.Log("Haciendo cosas de Reloj3");
        Debug.Log(PlayFabManager.nombreVisitante);
        textValueC5 = "Bienvenido de vuelta, recuerda seleccionar alguna de \n las dos puertas para continuar explorando nuestra empresa.";
        StartCoroutine(Reloj3());
    }

    public void UsuarioNoRegistrado()
    {
        Debug.Log("Haciendo cosas de Reloj");
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        recepcionista.SetTrigger("Saludo");
        foreach (char character in textValue)
        {
            textElement.text = textElement.text + character;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2);
        textElement.text = "";

        foreach (char character in textValue2)
        {
            textElement.text = textElement.text + character;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2);
        textElement.text = "";

        mirarE = true;
        recepcionista.SetTrigger("Idle");
        efectoConexito.SetActive(true);

        yield return new WaitForSeconds(2);

        mirar = true;
        conexito.SetActive(true);

        yield return new WaitForSeconds(1);
        
        conexito.transform.LookAt(guiaConexitoGafas.transform.position);

        foreach (char character in textValueC1)
        {
            textElement2.text = textElement2.text + character;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2);
        textElement2.text = "";

        foreach (char character in textValueC2)
        {
            textElement2.text = textElement2.text + character;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2);
        textElement2.text = "";

        animConexito.SetTrigger("EntregaGafas");
        gafasObj.SetActive(true);
        yield return new WaitForSeconds(1);
        animConexito.enabled = false;
        gafas = true;
        efectoConexito.SetActive(false);

        yield return new WaitForSeconds(1);

        foreach (char character in textValueC3)
        {
            textElement2.text = textElement2.text + character;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void ConexitoPoneGafas()
    {
        if(gafas == true)
        {
            float velocidadmovconexito = velocidadConexito * Time.deltaTime;
            conexito.transform.position = Vector3.MoveTowards(conexito.transform.position, guiaConexitoGafas.transform.position, velocidadmovconexito);
        }
        
    }

    void Registro()
    {
        if(SelectionManager.pcElegido == true)
        {
            textElement2.text = "";
        }
    }

    IEnumerator Reloj2()
    {
        recepcionista.SetTrigger("Register");
        foreach (char character in textValueC4)
        {
            textElement.text = textElement.text + character;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2);
        textElement.text = "";
        recepcionista.SetTrigger("Idle");
        fondoTextos.SetActive(false);
    }

    IEnumerator Reloj3()
    {
        botonModificar.SetActive(true);
        recepcionista.SetTrigger("Register");
        interactividad.enabled = false;
        characterData.nombreInput.interactable = false;
        characterData.personaNaturalToggle.interactable = false;
        characterData.empresaToggle.interactable = false;
        characterData.nombreEmpresaInput.interactable = false;
        characterData.cargoInput.interactable = false;
        characterData.correoInput.interactable = false;
        MouseLook.horizontalValue = 80;

        foreach (char character in textValueC5)
        {
            textElement.text = textElement.text + character;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2);
        textElement.text = "";
        mirar = true;
        conexito.SetActive(true);
        animConexito.SetTrigger("EntregaGafas");
        gafasObj.SetActive(true);
        yield return new WaitForSeconds(1);
        animConexito.enabled = false;
        gafas = true;
        efectoConexito.SetActive(false);
        fondoTextos.SetActive(false);
        interactividad.enabled = true;
        recepcionista.SetTrigger("Idle");
        
    }

    public void DialogoPuertas()
    {
        StartCoroutine(Reloj2());
    }

    void MirarEConexito()
    {
        if(mirarE == true)
        {
            cam.transform.LookAt(efectoConexito.transform.position);
        }
        
    }

    void MirarConexito()
    {
        if(mirar == true)
        {
            cam.transform.LookAt(conexito.transform.position);
        }
        
    }
}
