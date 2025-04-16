using UnityEngine;

public enum GameContext
{
    Default,
    EnDialogo,
    EnInteraccion,
    EnCinematica,
    EnMenu
}

public class GameManager : MonoBehaviour, IGameManager
{
    public GameContext ContextoActual { get; private set; } = GameContext.Default;
    private bool _estaPausado = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CambiarContexto(GameContext.Default);
    }

    public void CambiarContexto(GameContext nuevoContexto)
    {
        ContextoActual = nuevoContexto;
        Debug.Log($"Contexto cambiado a: {nuevoContexto}");
    }

    public bool EstaEnContexto(GameContext contexto)
    {
        return ContextoActual == contexto;
    }

    public void PausarJuego(bool pausar)
    {
        _estaPausado = pausar;
        Time.timeScale = pausar ? 0 : 1;
        MouseState.Instance.LockCursor(!pausar); // opcional: solo si quieres liberar el cursor al pausar
        CambiarContexto(pausar ? GameContext.EnMenu : GameContext.Default);
    }

    public bool EstaPausado()
    {
        return _estaPausado;
    }
}
