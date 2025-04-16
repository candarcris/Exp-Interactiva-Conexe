using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class CuadroValoresInteractivo : ObjetoInteractivo
{
    public CuadroHonorShow _cuadroValores3D;
    public GameObject _fade;
    public GameObject _cerrarUIButtonImage;

    private IGameManager gameManagerInterface;

    protected override void Start()
    {
        base.Start();
        gameManagerInterface = ManagerLocator.Instance.Get<IGameManager>();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void ObjetoSeleccionado() 
    {
        base.ObjetoSeleccionado();
        _cuadroValores3D.gameObject.SetActive(true);
        _fade.SetActive(true);
        _cerrarUIButtonImage.SetActive(true);
        ManagerLocator.Instance.Get<IPathCharacter>().PoderObservar(false);
    }

    public override void ObjetoDeseleccionado()
    {
        base.ObjetoDeseleccionado();
        _cuadroValores3D.gameObject.SetActive(false);
        _fade.SetActive(false);
        _cerrarUIButtonImage.SetActive(false);
        ManagerLocator.Instance.Get<IPathCharacter>().PoderObservar(true);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && gameManagerInterface.EstaEnContexto(GameContext.EnInteraccion))
        {
            ObjetoDeseleccionado();
        }
    }
}
