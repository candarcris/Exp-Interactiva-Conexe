using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public Camera _camera;

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.TryGetComponent<ObjetoInteractivo>(out var selection))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    selection.ObjetoSeleccionado();
                }
            }
        }
    }
}
