using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _uiActual;
    private IGameManager gameManagerInterface;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        gameManagerInterface = ManagerLocator.Instance.Get<IGameManager>();
    }

    public void MostrarUI(GameObject nuevoUI)
    {
        if (_uiActual != null) _uiActual.SetActive(false); // Oculta el anterior
        _uiActual = nuevoUI;
        _uiActual?.SetActive(true);

        gameManagerInterface.CambiarContexto(GameContext.EnInteraccion);
    }

    public void OcultarUIActual()
    {
        if (_uiActual != null)
        {
            _uiActual.SetActive(false);
            _uiActual = null;
        }

        gameManagerInterface.CambiarContexto(GameContext.Default);
    }

    private void PausarJuego(bool pausar)
    {
        gameManagerInterface.PausarJuego(pausar);
    }
}
