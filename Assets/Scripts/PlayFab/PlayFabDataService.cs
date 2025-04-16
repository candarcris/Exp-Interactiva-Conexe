using PlayFab.ClientModels;
using PlayFab;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabDataService : IDataService
{
    public void SaveData(Character character, Action onSuccess, Action<string> onError)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Nombre", character.nombre },
                { "Correo", character.correo },
                { "Contraseña", character.contraseña }
            }
        };

        PlayFabClientAPI.UpdateUserData(request,
            result => onSuccess?.Invoke(),
            error => onError?.Invoke(error.ErrorMessage));
    }

    public void LoadData(Action<Character> onDataLoaded, Action<string> onError)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(),
            result =>
            {
                if (result.Data.ContainsKey("Nombre"))
                {
                    var character = new Character(
                        result.Data["Nombre"].Value,
                        result.Data["Correo"].Value,
                        result.Data["Contraseña"].Value
                    );
                    onDataLoaded?.Invoke(character);
                }
                else
                {
                    onError?.Invoke("No hay datos guardados.");
                }
            },
            error => onError?.Invoke(error.ErrorMessage));
    }
}
