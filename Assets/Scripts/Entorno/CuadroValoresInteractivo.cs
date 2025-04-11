using UnityEngine;

public class CuadroValoresInteractivo : ObjetoInteractivo
{
    public CuadroHonorShow _cuadroValores3D;
    public override void ObjetoSeleccionado()
    {
        base.ObjetoSeleccionado();
        _cuadroValores3D.gameObject.SetActive(true);
        Debug.Log("Cuadro valores seleccionado.");
    }
}
