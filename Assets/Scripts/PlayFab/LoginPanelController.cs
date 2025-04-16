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

        if (string.IsNullOrEmpty(character.correo) || string.IsNullOrEmpty(character.contrase�a))
        {
            Debug.LogWarning("Correo o contrase�a vac�os.");
            return;
        }

        _playerSessionManager.Login(character);
    }
}
