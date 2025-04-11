using UnityEngine;
using System;
using System.Collections.Generic;

public class ManagerLocator : MonoBehaviour
{
    public static ManagerLocator Instance { get; private set; }

    private Dictionary<Type, object> _managers = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Register<T>(T manager) where T : class
    {
        var type = typeof(T);
        if (!_managers.ContainsKey(type))
        {
            _managers.Add(type, manager);
        }
        else
        {
            Debug.LogWarning($"Manager del tipo {type} ya está registrado.");
        }
    }

    public T Get<T>() where T : class
    {
        var type = typeof(T);
        if (_managers.TryGetValue(type, out var manager))
        {
            return manager as T;
        }

        Debug.LogWarning($"Manager del tipo {type} no está registrado.");
        return null;
    }
}
