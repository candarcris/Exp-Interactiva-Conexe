using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public PathCharacter personaje;
    public Animator transition;

    private void Start()
    {
        personaje = FindAnyObjectByType<PathCharacter>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            switch (this.tag)
            {
                case "PuertaLab":
                    personaje.velocidad = 0;
                    StartCoroutine(LoadLevel(2));
                    break;

                case "PuertaOfice":
                    personaje.velocidad = 0;
                    StartCoroutine(LoadLevel(3));
                    break;
            }
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {       
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
