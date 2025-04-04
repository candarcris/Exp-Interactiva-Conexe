using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public CharacterData characterData;
    public DialogoEventos dialogoEventos;
    public static string nombreVisitante;
    public Button aceptarLogin;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Registrado") || PlayerPrefs.GetInt("Registrado") == 0)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("No registrado: se borran los datos");
        }
        else
        {
            Debug.Log("Ya registrado: se conservan datos");
        }

        DontDestroyOnLoad(this.gameObject); // Si quieres que este objeto viva entre escenas
    }

    private void Start()
    {
        aceptarLogin.onClick.AddListener(() => Login(characterData.correoInput.text, characterData.contraseñaInput.text));
    }

    // -------------------- LOGIN --------------------
    public void Login(string email, string password)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = password
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccessLogin, OnError);
    }

    void OnSuccessLogin(LoginResult result)
    {
        Debug.Log("Login exitoso");
        GetData();  // Cargar datos del usuario
    }

    // -------------------- REGISTRO --------------------
    public void Register(string email, string password)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = password,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSuccessRegister, OnError);
    }

    void OnSuccessRegister(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registro exitoso");
        SaveData();  // Guardar los datos del usuario en PlayFab

        PlayerPrefs.SetInt("Registrado", 1);
        PlayerPrefs.Save(); // Opcional pero seguro
    }

    // -------------------- GUARDAR DATOS --------------------
    public void SaveData()
    {
        Character character = characterData.GetCharacterData();

        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Nombre", character.nombre },
                { "Correo", character.correo },
                { "Contraseña", character.contraseña }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

        PlayerPrefs.SetString("Nombre", character.nombre);
        PlayerPrefs.SetString("Correo", character.correo);
        PlayerPrefs.SetInt("Registrado", 1);
        PlayerPrefs.Save();
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Datos guardados en PlayFab");
    }

    // -------------------- OBTENER DATOS --------------------
    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result)
    {
        if (result.Data.ContainsKey("Nombre"))
        {
            nombreVisitante = result.Data["Nombre"].Value;
        }

        Debug.Log("Datos recibidos");

        if (result.Data.ContainsKey("Nombre") && result.Data.ContainsKey("Correo"))
        {
            Debug.Log("Usuario registrado");
            dialogoEventos.UsuarioRegistrado();

            Character character = new Character(
                result.Data["Nombre"].Value,
                result.Data["Correo"].Value,
                result.Data["Contraseña"].Value
            );

            characterData.SetUI(character);
        }
        else
        {
            Debug.Log("Usuario nuevo o sin datos");
            dialogoEventos.UsuarioNoRegistrado();
            characterData.ClearUI();
        }
    }

    // -------------------- ERROR HANDLING --------------------
    void OnError(PlayFabError error)
    {
        Debug.Log("Error en PlayFab: " + error.GenerateErrorReport());
    }

    private void OnApplicationQuit()
    {
        if (!PlayerPrefs.HasKey("Registrado") || PlayerPrefs.GetInt("Registrado") == 0)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("El jugador no estaba registrado, se borran los PlayerPrefs al salir.");
        }
        else
        {
            Debug.Log("Jugador registrado, se conservan los datos.");
        }
    }
}
