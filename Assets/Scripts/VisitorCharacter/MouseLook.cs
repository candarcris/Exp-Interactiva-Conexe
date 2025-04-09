using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    private float horizontal;
    private float vertical;

    public static float speed;
    public static float horizontalValue;

    private float rotacionCabeceo = 0;

    public Camera _camera;
    [SerializeField] SelectionManager _selectionManager;


    void Start()
    {
        _camera = GetComponent<Camera>();
        _selectionManager = ManagerLocator.Instance._selectionManager;
        rotacionCabeceo = transform.rotation.x;
        speed = 5;
        horizontalValue = 60;
    }

    void Update()
    {
        Ray rayo = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay(rayo.origin, rayo.direction * 100, Color.red);

        if (Physics.Raycast(rayo, out hit))
        {
            if (hit.transform.TryGetComponent<ObjetoInteractivo>(out var selection))
            {
                foreach (var objeto in _selectionManager._objetosInteractivosList)
                {
                    objeto.ActivarAura(objeto == selection);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    selection.ObjetoSeleccionado();
                }
            }
        }
    }

    public void ActivarMouseLook()
    {

            horizontal += speed * Input.GetAxis("Mouse X");
            horizontal = Mathf.Clamp(horizontal, -horizontalValue, horizontalValue);
            // en horizontal poner -80, 80 para vision normal.

            vertical -= speed * Input.GetAxis("Mouse Y");
            vertical = Mathf.Clamp(vertical, -15, 30);

            transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);
    }

    public void MouseLook80()
    {
        horizontalValue = 80;
    }
}
