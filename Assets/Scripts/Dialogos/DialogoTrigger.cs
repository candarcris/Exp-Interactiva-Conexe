using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{
    public Dialogo dialogo; // ScriptableObject asignado desde el Inspector
    public bool activarDialogo;

    public void EjecutarDialogo()
    {
        if (activarDialogo)
        {
            DialogoUI.Instance.IniciarDialogo(dialogo);
        }
    }
}
