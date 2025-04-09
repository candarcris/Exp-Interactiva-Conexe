using UnityEngine;
using UnityEngine.UI;

public abstract class ObjetoInteractivo : MonoBehaviour
{
    public GameObject _vfxAura;
    [SerializeField] private MouseState _mouseState;

    private void Start()
    {
        _mouseState = ManagerLocator.Instance._mouseState.GetComponent<MouseState>();
    }

    public virtual void ObjetoSeleccionado()
    {
        PausarJuego(true);
    }

    public void PausarJuego(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        if(_mouseState != null)
        {
            _mouseState.OnApplicationFocus(!pause);
        }
    }

    public void ActivarAura(bool vfxActivado)
    {
        _vfxAura.SetActive(vfxActivado);
    }

}
