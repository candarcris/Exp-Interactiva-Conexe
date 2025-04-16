using UnityEngine;

public interface IAuthService
{
    void Register(string email, string password, System.Action onSuccess, System.Action<string> onError);
    void Login(string email, string password, System.Action onSuccess, System.Action<string> onError);
}
