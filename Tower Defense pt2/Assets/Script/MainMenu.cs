using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public String load = "Level Selector";
    public Loading loading;
    
    public void Play()
    {
        loading.FadeTo(load);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void Reset()
    {
        LevelSelector.ResetPrefs();
    }
}
