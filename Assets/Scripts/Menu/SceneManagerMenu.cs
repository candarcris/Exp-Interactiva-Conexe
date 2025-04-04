using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerMenu : MonoBehaviour
{
    public Button _nuevoVisitanteButton;
    public Button _continuarButton;

    private void Start()
    {
        _nuevoVisitanteButton.onClick.AddListener(LoadScene);
        _continuarButton.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
