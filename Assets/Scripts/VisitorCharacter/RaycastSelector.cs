using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public Camera _camera;
    public bool _dispararRayCast;

    private void Start()
    {
        var eventManager = ManagerLocator.Instance.Get<IInteractiveEventManager>();
        if (eventManager != null)
        {
            eventManager.OnGafasEntregadas += DispararRaycast;
        }
    }

    private void OnDestroy()
    {
        var eventManager = ManagerLocator.Instance.Get<IInteractiveEventManager>();
        if (eventManager != null)
        {
            eventManager.OnGafasEntregadas -= DispararRaycast;
        }
    }

    public void DispararRaycast()
    {
        _dispararRayCast = true;
    }

    void Update()
    {
        if (!_dispararRayCast) return;

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
