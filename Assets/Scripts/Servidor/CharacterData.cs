using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character
{
    public string nombre;
    public string correo;
    public string contraseña;

    public Character(string nombre, string correo, string contraseña)
    {
        this.nombre = nombre;
        this.correo = correo;
        this.contraseña = contraseña;
    }

    public Character() { }
}

public class CharacterData : MonoBehaviour
{
    public TMP_InputField nombreInput;
    public TMP_InputField correoInput;
    public TMP_InputField contraseñaInput;
    public Button registerButton;

    private IPlayerSessionManager _playerSessionManager;

    private void Awake()
    {
        _playerSessionManager = ManagerLocator.Instance.Get<IPlayerSessionManager>();
        registerButton.onClick.AddListener(OnRegisterClicked);

        // Configurar los límites de caracteres
        nombreInput.characterLimit = 40;
        correoInput.characterLimit = 40;
        contraseñaInput.characterLimit = 8;

        // Asegurar que siempre comience limpio
        ClearUI();
    }

    private void OnRegisterClicked()
    {
        Character character = GetCharacterData();

        if (string.IsNullOrEmpty(character.correo) || string.IsNullOrEmpty(character.contraseña))
        {
            Debug.LogWarning("Correo o contraseña vacíos");
            return;
        }

        _playerSessionManager.Register(character);
    }

    public Character GetCharacterData()
    {
        return new Character(
            nombreInput.text,
            correoInput.text,
            contraseñaInput.text
        );
    }

    public void SetUI(Character character)
    {
        nombreInput.text = character.nombre;
        correoInput.text = character.correo;
        contraseñaInput.text = character.contraseña;
    }

    public void ClearUI()
    {
        nombreInput.text = "";
        correoInput.text = "";
        contraseñaInput.text = "";
    }
}
