using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            if(this.tag == "PuertaOfice")
            {
                LoadLab(2);
            }
            else if(this.tag == "PuertaLab")
            {
                LoadLab(1);
            }
        }
    }

    public void LoadLab(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
