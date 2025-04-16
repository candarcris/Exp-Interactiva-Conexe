using UnityEngine;
using UnityEngine.UI;

public abstract class ObjetoInteractivo : MonoBehaviour
{
    public GameObject _vfxAura;
    [SerializeField] private GameObject _uiAsociado;

    protected virtual void Start()
    {
        var eventManager = ManagerLocator.Instance.Get<IInteractiveEventManager>();
        if (eventManager != null)
        {
            eventManager.OnGafasEntregadas += ActivarAura;
        }
    }

    protected virtual void OnDestroy()
    {
        var eventManager = ManagerLocator.Instance.Get<IInteractiveEventManager>();
        if (eventManager != null)
        {
            eventManager.OnGafasEntregadas -= ActivarAura;
        }
    }

    public virtual void ObjetoSeleccionado()
    {
        ManagerLocator.Instance.Get<UIManager>()?.MostrarUI(_uiAsociado);
    }

    public virtual void ObjetoDeseleccionado()
    {
        ManagerLocator.Instance.Get<UIManager>()?.OcultarUIActual();
    }

    public void ActivarAura(bool vfxActivado)
    {
        _vfxAura.SetActive(vfxActivado);
    }

    protected void ActivarAura()
    {
        ActivarAura(true);
    }
}
