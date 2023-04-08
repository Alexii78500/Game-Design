using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool ended;
    public GameObject GOUI;
    public GameObject EndScreen;
    public static GameManager instance;

    public Loading loading;

    private void Start()
    {
        GOUI.SetActive(false);
        ended = false;
        instance = this;
        
        //Set current level (max 9)
        string level = SceneManager.GetActiveScene().name[6].ToString();
        PlayerPrefs.SetInt("CurrentLevel", (Int32.Parse(level)));
    }

    // Update is called once per frame
    void Update()
    {
        //Game ended
        if (ended)
            return;
        
        if (PlayerStats.Hp <= 0 || Input.GetKeyDown("e"))
            EndGame();
    }

    void EndGame()
    {
        ended = true;
        GOUI.SetActive(true);
    }

    public void WinLevel()
    {
        EndScreen.gameObject.SetActive(true);
        ended = true;
    }

    public void NextLevel()
    {

        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int maxLevel = PlayerPrefs.GetInt("maxLevel");
        if (maxLevel == currentLevel)
        {
            maxLevel++;
            PlayerPrefs.SetInt("maxLevel", maxLevel);
        }

        currentLevel++;
        string SceneToLoad = "Level " + currentLevel;
        loading.FadeTo(SceneToLoad);
        
    }

    public void UnlockNext()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int maxLevel = PlayerPrefs.GetInt("maxLevel");
        if (maxLevel == currentLevel)
        {
            maxLevel++;
            PlayerPrefs.SetInt("maxLevel", maxLevel);
        }
    }
}
