using UnityEngine;

public interface IPathCharacter
{
    void MoverAPunto(PuntoDeRuta punto);
    void SetEnfoque(Transform objetivo);
    void CancelarEnfoque();
    void PoderObservar(bool value);
}
