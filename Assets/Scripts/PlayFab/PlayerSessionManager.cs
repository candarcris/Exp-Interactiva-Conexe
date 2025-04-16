using UnityEngine;

public class PlayerSessionManager : MonoBehaviour, IPlayerSessionManager
{
    private IAuthService _authService;
    private IDataService _dataService;

    public CharacterData characterData;
    public LoginPanelController loginPanel;

    private void Awake()
    {
        if (FindObjectsByType<PlayerSessionManager>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        _authService = new PlayFabAuthService();
        _dataService = new PlayFabDataService();

        if (characterData == null)
        {
            CharacterData[] todosCharacterData = Resources.FindObjectsOfTypeAll<CharacterData>();
            foreach (var comp in todosCharacterData)
            {
                characterData = comp;
            }
        }

        if (loginPanel == null)
        {
            LoginPanelController[] todosLoginPanel = Resources.FindObjectsOfTypeAll<LoginPanelController>();
            foreach (var comp in todosLoginPanel)
            {
                loginPanel = comp;
            }
        }
    }

    public void Register(Character character)
    {
        if (character == null)
        {
            Debug.LogWarning("Character es nulo.");
            return;
        }

        _authService.Register(character.correo, character.contraseña,
            onSuccess: () =>
            {
                _dataService.SaveData(character,
                    onSuccess: () =>
                    {
                        Debug.Log("Registro y datos guardados.");
                        loginPanel?.gameObject.SetActive(false);
                    },
                    onError: error => Debug.LogError(error)
                );
            },
            onError: error => Debug.LogError("Error en registro: " + error)
        );
    }

    public void Login(Character character)
    {
        _authService.Login(character.correo, character.contraseña,
            onSuccess: () =>
            {
                _dataService.LoadData(
                    onDataLoaded: loadedCharacter =>
                    {
                        characterData?.SetUI(loadedCharacter);
                        loginPanel?.gameObject.SetActive(false);
                        Debug.Log("Login exitoso. Datos cargados.");
                    },
                    onError: error => Debug.LogError(error)
                );
            },
            onError: error => Debug.LogError("Error en login: " + error)
        );
    }

    public void OnAceptarLogin()
    {
        Character character = characterData.GetCharacterData();
        Login(character);
    }
}
