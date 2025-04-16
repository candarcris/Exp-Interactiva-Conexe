using UnityEngine;

public interface IDataService
{
    void SaveData(Character character, System.Action onSuccess, System.Action<string> onError);
    void LoadData(System.Action<Character> onDataLoaded, System.Action<string> onError);
}
