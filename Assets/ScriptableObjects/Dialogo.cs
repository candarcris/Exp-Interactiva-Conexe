using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoDialogo", menuName = "Scriptable Objects/Dialogo")]
public class Dialogo : ScriptableObject
{
    public List<LineaDialogo> lineas;
}
