using UnityEngine;

public class LobbySetUp : MonoBehaviour
{
    public PathCharacter _character;
    private void Start()
    {
        _character.MoverAPunto(_character.guiasRuta[0].GetComponent<PuntoDeRuta>());
    }
}
