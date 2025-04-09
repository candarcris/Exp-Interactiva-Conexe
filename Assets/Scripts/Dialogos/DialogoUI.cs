using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Linq;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class DialogoUI : MonoBehaviour
{
    public static DialogoUI Instance { get; private set; }

    public TMP_Text nombreTexto;
    public TMP_Text dialogoTexto;
    [SerializeField] private Dialogo dialogoActual;

    public GameObject dialogueItems;
    public Image enterBtn;
    private int indice = 0;
    public bool textoCompletado;
    private Animator dialogueAnimator;


    private void Awake()
    {
        dialogueAnimator = dialogueItems.GetComponent<Animator>();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // evita duplicados
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void IniciarDialogo(Dialogo dialogo)
    {
        dialogoActual = dialogo;
        indice = 0;
        MostrarLineaActual();
    }

    public void MostrarLineaActual()
    {
        if (indice >= dialogoActual.lineas.Count) return;

        dialogueItems.SetActive(true);
        var linea = dialogoActual.lineas[indice];

        nombreTexto.text = linea.personaje._nombrePersonaje;
        dialogoTexto.color = linea.personaje._colorTexto;
        dialogoTexto.font = linea.personaje._fuenteTexto;
        dialogoTexto.fontSize = linea.personaje._fontSize;

        StartCoroutine(AnimarTextoDialogo(linea.texto));

        if (linea.activarEvento)
        {
            ManagerLocator.Instance._eventManager.EjecutarEvento(linea.idEvento);
        }
    }

    private IEnumerator AnimarTextoDialogo(string texto)
    {
        enterBtn.gameObject.SetActive(false);

        string textoFormateado = texto.Replace("\\n", "\n");
        textoCompletado = false;
        dialogoTexto.text = "";

        foreach (char character in textoFormateado)
        {
            dialogoTexto.text += character;
            yield return new WaitForSeconds(0.03f);
        }

        textoCompletado = true;
        enterBtn.gameObject.SetActive(true);
    }

    public void SiguienteLinea()
    {
        indice++;
        if (indice < dialogoActual.lineas.Count)
        {
            MostrarLineaActual();
        }
            
        else
        {
            FinalizarDialogo();
        }
    }

    public void FinalizarDialogo()
    {
        dialogueAnimator.SetTrigger("DialogueOut");
        Debug.Log("Fin del diálogo");
        // Ocultar panel o pasar a siguiente evento
    }

    public void PasarSiguienteLinea()
    {
        if(textoCompletado)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) // o la tecla que quieras
            {
                DialogoUI.Instance.SiguienteLinea();
            }
        }
    }

    private void Update()
    {
        PasarSiguienteLinea();
    }
}
