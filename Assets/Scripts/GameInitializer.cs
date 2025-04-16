using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _gameManagerPrefab;
    [SerializeField] private GameObject _uiManagerPrefab;
    [SerializeField] private GameObject _eventSystemPrefab;
    [SerializeField] private GameObject _playerSessionPrefab;
    [SerializeField] private GameObject _interactiveEventManagerPrefab;
    [SerializeField] private GameObject _pathCharacterPrefab;

    private void Awake()
    {
        if (FindFirstObjectByType<GameManager>() == null)
            Instantiate(_gameManagerPrefab);

        if (FindFirstObjectByType<UIManager>() == null)
            Instantiate(_uiManagerPrefab);

        if (FindFirstObjectByType<EventSystem>() == null)
            Instantiate(_eventSystemPrefab);

        if (FindFirstObjectByType<PlayerSessionManager>() == null)
            Instantiate(_playerSessionPrefab);

        if (FindFirstObjectByType<InteractiveEventManager>() == null)
            Instantiate(_interactiveEventManagerPrefab);

        if (FindFirstObjectByType<PathCharacter>() == null)
            Instantiate(_pathCharacterPrefab);

        // Registrar
        ManagerLocator.Instance.Register<IGameManager>(FindFirstObjectByType<GameManager>());
        ManagerLocator.Instance.Register<UIManager>(FindFirstObjectByType<UIManager>());
        ManagerLocator.Instance.Register<IEventSystem>(FindFirstObjectByType<EventSystem>());
        ManagerLocator.Instance.Register<IPlayerSessionManager>(FindFirstObjectByType<PlayerSessionManager>());
        ManagerLocator.Instance.Register<IInteractiveEventManager>(FindFirstObjectByType<InteractiveEventManager>());
        ManagerLocator.Instance.Register<IPathCharacter>(FindFirstObjectByType<PathCharacter>());
    }
}
