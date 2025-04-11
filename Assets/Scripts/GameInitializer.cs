using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private EventSystem _eventSystem;

    private void Awake()
    {
        // Registrar en el orden correcto
        ManagerLocator.Instance.Register<IGameManager>(_gameManager);
        ManagerLocator.Instance.Register<UIManager>(_uiManager);
        ManagerLocator.Instance.Register<IEventSystem>(_eventSystem);

        // Puedes hacer logs para asegurarte
        Debug.Log("Managers registrados desde GameInit");
    }
}
