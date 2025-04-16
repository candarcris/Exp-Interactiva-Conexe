using UnityEngine;

public class PCInteractivo : ObjetoInteractivo
{
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
        _fade.SetActive(true);
        _cerrarUIButtonImage.SetActive(true);
        MouseState.Instance.LockCursor(false);
        ManagerLocator.Instance.Get<IPathCharacter>().PoderObservar(false);
    }

    public override void ObjetoDeseleccionado()
    {
        base.ObjetoDeseleccionado();
        _fade.SetActive(false);
        _cerrarUIButtonImage.SetActive(false);
        MouseState.Instance.LockCursor(true);
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
