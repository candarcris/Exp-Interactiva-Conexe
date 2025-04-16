using PlayFab.ClientModels;
using PlayFab;
using System;
using UnityEngine;

public class PlayFabAuthService : IAuthService
{
    public void Register(string email, string password, Action onSuccess, Action<string> onError)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = password,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request,
            result => onSuccess?.Invoke(),
            error => onError?.Invoke(error.ErrorMessage));
    }

    public void Login(string email, string password, Action onSuccess, Action<string> onError)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = password
        };

        PlayFabClientAPI.LoginWithEmailAddress(request,
            result => onSuccess?.Invoke(),
            error => onError?.Invoke(error.ErrorMessage));
    }
}
