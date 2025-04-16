using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelController : MonoBehaviour
{
    public Button loginButton;
    public CharacterData characterData;
    private IPlayerSessionManager _playerSessionManager;

    private void Awake()
    {
        _playerSessionManager = ManagerLocator.Instance.Get<IPlayerSessionManager>(); 

        loginButton.onClick.AddListener(OnLoginClicked);
    }
    
    private void OnLoginClicked()
    {
        Character character = characterData.GetCharacterData();

        if (string.IsNullOrEmpty(character.correo) || string.IsNullOrEmpty(character.contraseña))
        {
            Debug.LogWarning("Correo o contraseña vacíos.");
            return;
        }

        _playerSessionManager.Login(character);
    }
}
