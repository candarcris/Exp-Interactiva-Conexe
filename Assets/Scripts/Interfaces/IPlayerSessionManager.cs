using UnityEngine;

public interface IPlayerSessionManager
{
    void Register(Character character);
    void Login(Character character);
}
