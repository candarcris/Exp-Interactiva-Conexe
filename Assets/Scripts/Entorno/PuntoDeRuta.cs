using UnityEngine;

public class PuntoDeRuta : MonoBehaviour
{
    public bool activarObservacion;
    [HideInInspector] public DialogoTrigger dialogoTrigger;

    private void Awake()
    {
        dialogoTrigger = GetComponent<DialogoTrigger>();
    }
}
