using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadroHonorShow : MonoBehaviour
{
    public Transform guiaAparece;
    private GameObject target;
    float rotSpeed = 1000;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");

        if (target != null) // Si tiene target (objetivo)
        {
            transform.LookAt(target.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() 
    {

        transform.parent = guiaAparece.transform;
        transform.position = guiaAparece.transform.position;
    }

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, -rotY);
    }
}
