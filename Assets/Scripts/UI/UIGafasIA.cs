using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIGafasIA : MonoBehaviour
{
    public List<GameObject> _itemsInterfazList = new();
    [SerializeField] private Conexito _conexito;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _conexito.OnGafasEntregadas += MostrarInterfazGafas;
    }

    public void MostrarInterfazGafas()
    {
        foreach(GameObject item in _itemsInterfazList)
        {
            item.SetActive(true);
        }
    }
}
