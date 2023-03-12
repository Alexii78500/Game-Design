using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene(string scene)
    {
        StartCoroutine(LoadAndSetup(scene));
    }

    IEnumerator LoadAndSetup(string scene)
    {
        //Load Scene
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        
        //Wait one frame
        yield return null;

        //Get Manager object
        if (scene == "Game")
        {
            Manager manager = FindObjectOfType<Manager>();
            manager.StartGame(); 
        }
        
    }
}
