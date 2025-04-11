using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseState : MonoBehaviour
{
    public static MouseState Instance { get; private set; }

    private void Awake()
    {
        var instances = FindObjectsByType<MouseState>(FindObjectsSortMode.None);
        if (instances.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LockCursor(true);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        LockCursor(hasFocus);
    }

    public void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}

