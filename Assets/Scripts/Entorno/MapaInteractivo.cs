using UnityEngine;

public class MapaInteractivo : ObjetoInteractivo
{
    public override void ObjetoSeleccionado()
    {
        base.ObjetoSeleccionado();
        Debug.Log("Espichado el mapa");
    }
}
