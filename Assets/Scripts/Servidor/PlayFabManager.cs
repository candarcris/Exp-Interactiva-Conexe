using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour
{

    public CharacterData characterData;
    public DialogoEventos dialogoEventos;
    public static string nombreVisitante;
    
    
    //string compareCorreo;

    void Awake()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    //public void CompareData()
    //{
    //    var request = new ExecuteCloudScriptRequest
    //    {
    //        FunctionName = "Compare"
    //    };
    //    PlayFabClientAPI.ExecuteCloudScript(request, OnExecuteSuccess, OnError);
    //}

    //void OnExecuteSuccess(ExecuteCloudScriptResult result)
    //{
    //    
    //}

    public void SaveData()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Nombre", characterData.nombreInput.text },
                { "Natural", characterData.personaNaturalToggle.isOn.ToString() },
                { "Empresa", characterData.empresaToggle.isOn.ToString() },
                { "NEmpresa", characterData.nombreEmpresaInput.text },
                { "Cargo", characterData.cargoInput.text },
                { "Correo", characterData.correoInput.text }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successful user data send");
    }


    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        //solucionar el problema de revisar si el usuario esta o no registrado al comienzo del juego
        //cambiar if con los valores de los campos
        Debug.Log("Recieved user data");
        if(result.Data.ContainsKey("Nombre") && result.Data["Nombre"].Value != null && result.Data.ContainsKey("Correo") && result.Data["Correo"].Value != null)
        {
            Debug.Log("Usuario registrado");
            dialogoEventos.UsuarioRegistrado();
            
            characterData.personaNaturalToggle.isOn = bool.Parse(result.Data["Natural"].Value);
            characterData.empresaToggle.isOn = bool.Parse(result.Data["Empresa"].Value);
            characterData.nombreInput.text = result.Data["Nombre"].Value;
            characterData.nombreEmpresaInput.text = result.Data["NEmpresa"].Value;
            characterData.cargoInput.text = result.Data["Cargo"].Value;
            characterData.correoInput.text = result.Data["Correo"].Value;
        }
        else
        {
            Debug.Log("Usuario nuevo / Datos incompletos");
            dialogoEventos.UsuarioNoRegistrado();
        }
        //nombreVisitante = result.Data["Nombre"].Value;
    }

    
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while login/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
}
