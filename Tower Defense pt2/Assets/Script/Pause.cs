using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject PauseMenu;
    public Loading loading;
    string menu = "Main Menu";

    // Update is called once per frame
    void Update()
    {
        //Enables / disables the menu
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    void Toggle()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);

        //Pauses time
        if (PauseMenu.activeSelf)
            Time.timeScale = 0f;
        
        //Sets time back to normal
        else
            Time.timeScale = 1f;
    }

    public void Retry()
    {
        Toggle();
        loading.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        Toggle();
    }

    public void Menu()
    {
        Toggle();
        loading.FadeTo(menu);
    }
}
