using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Scriptable Objects/Personaje")]
public class Personaje : ScriptableObject
{
    public string _nombrePersonaje;
    public Color _colorTexto;
    public TMP_FontAsset _fuenteTexto;
    public int _fontSize;
}
