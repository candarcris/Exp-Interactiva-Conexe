using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIGafasIA : MonoBehaviour
{
    public List<GameObject> _itemsInterfazList = new();
    [SerializeField] private Conexito _conexito;

    private void Start()
    {
        var eventManager = ManagerLocator.Instance.Get<IInteractiveEventManager>();
        if (eventManager != null)
        {
            eventManager.OnGafasEntregadas += MostrarInterfazGafas;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        var eventManager = ManagerLocator.Instance.Get<IInteractiveEventManager>();
        if (eventManager != null)
        {
            eventManager.OnGafasEntregadas -= MostrarInterfazGafas;
        }
    }

    public void MostrarInterfazGafas()
    {
        foreach(GameObject item in _itemsInterfazList)
        {
            item.SetActive(true);
        }
    }
}
