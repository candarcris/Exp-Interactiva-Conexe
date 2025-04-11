using UnityEngine;
using UnityEngine.UI;

public abstract class ObjetoInteractivo : MonoBehaviour
{
    public GameObject _vfxAura;
    [SerializeField] private GameObject _uiAsociado;

    public virtual void ObjetoSeleccionado()
    {
        ManagerLocator.Instance.Get<UIManager>()?.MostrarUI(_uiAsociado);
    }

    public void ActivarAura(bool vfxActivado)
    {
        _vfxAura.SetActive(vfxActivado);
    }
}
