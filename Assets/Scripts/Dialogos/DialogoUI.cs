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

    public int IndiceActual => indice;
    public Dialogo DialogoActual => dialogoActual;

    private IGameManager gameManagerInterface;
    private IEventSystem eventoInterface;


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

    private void Start()
    {
        gameManagerInterface = ManagerLocator.Instance.Get<IGameManager>();
        eventoInterface = ManagerLocator.Instance.Get<IEventSystem>();
    }

    public void IniciarDialogo(Dialogo dialogo)
    {
        dialogoActual = dialogo;
        indice = 0;
        MostrarLineaActual();
        gameManagerInterface.CambiarContexto(GameContext.EnDialogo);
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
            eventoInterface.EjecutarEvento(linea.idEvento);
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

    public void ContinuarDialogo()
    {
        dialogueAnimator.SetTrigger("DialogueIn");
        gameManagerInterface.CambiarContexto(GameContext.EnDialogo);
        SiguienteLinea();
    }

    public void FinalizarDialogo()
    {
        dialogueAnimator.SetTrigger("DialogueOut");
        gameManagerInterface.CambiarContexto(GameContext.Default);
    }

    public void PasarSiguienteLinea()
    {
        if (textoCompletado)
        {
            if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && gameManagerInterface.EstaEnContexto(GameContext.EnDialogo))
            {
                SiguienteLinea();
            }
        }
    }

    private void Update()
    {
        PasarSiguienteLinea();
    }
}
