using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    private float horizontal;
    private float vertical;

    public static float speed;
    public static float horizontalValue;

    float rotacionCabeceo = 0;

    // Start is called before the first frame update
    void Start()
    {
        rotacionCabeceo = transform.rotation.x;
        speed = 5;
        horizontalValue = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //ActivarMouseLook(true);
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
