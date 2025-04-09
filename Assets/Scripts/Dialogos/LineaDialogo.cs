using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LineaDialogo
{
    public Personaje personaje;
    [TextArea] public string texto;

    public bool activarEvento;
    public string idEvento; // Puede ser "AnimarJefe", "AparecerAliado", etc.
}
