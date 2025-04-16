using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float rotacionCabeceo = 0;

    public static float speed = 5;
    public static float horizontalValue = 60;

    private bool observacionActiva = false;


    void Update()
    {
        if (observacionActiva)
        {
            horizontal += speed * Input.GetAxis("Mouse X");
            horizontal = Mathf.Clamp(horizontal, -horizontalValue, horizontalValue);

            vertical -= speed * Input.GetAxis("Mouse Y");
            vertical = Mathf.Clamp(vertical, -15, 30);

            transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);
        }
    }

    public void ActivarObservacion()
    {
        observacionActiva = true;
    }

    public void DesactivarObservacion()
    {
        observacionActiva = false;
    }

    public void SetHorizontalLimit(float value)
    {
        horizontalValue = value;
    }
}
