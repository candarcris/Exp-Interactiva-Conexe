using UnityEngine;
using System.Collections.Generic;

public class ManagerLocator : MonoBehaviour
{
    public static ManagerLocator Instance { get; private set; }
    public PlayFabManager _playfabManager;
    public EventManager _eventManager;
    public MouseState _mouseState;
    public SelectionManager _selectionManager;


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
        if(_eventManager == null)
        {
            _eventManager = GetComponent<EventManager>();
        }
        if (_mouseState == null)
        {  
            _mouseState = GetComponent<MouseState>();
        }
        if(_selectionManager == null)
        {
            _selectionManager = GetComponent<SelectionManager>();
        }
    }
}
