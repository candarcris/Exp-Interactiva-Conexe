using UnityEngine;
using System.Collections.Generic;

public class ManagerLocator : MonoBehaviour
{
    public static ManagerLocator Instance { get; private set; }
    public PlayFabManager _playfabManager;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // Si ya existe una instancia, destruye esta copia
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (_playfabManager == null)
        {
            _playfabManager = GetComponent<PlayFabManager>();
        }
    }
}
