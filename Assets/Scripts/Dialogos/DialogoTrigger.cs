using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{
    public Dialogo dialogo; // ScriptableObject asignado desde el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogoUI.Instance.IniciarDialogo(dialogo); // <-- Aqu� se llama el di�logo
        }
    }
}
