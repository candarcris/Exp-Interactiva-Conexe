using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }

    public List<GameObject> _zoneItemsUIList = new();
    public GameObject _mirilla;
    public GameObject _diseñoInterface;
    public GameObject _fadeObjetos;
    public GameObject _transicionZonas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
