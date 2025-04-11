using UnityEngine;

public interface IGameManager
{
    void PausarJuego(bool pausar);
    bool EstaPausado();
    void CambiarContexto(GameContext nuevoContexto);
    bool EstaEnContexto(GameContext contexto);
}
