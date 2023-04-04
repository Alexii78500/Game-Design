using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;  
    public Loading loading;
    string menu = "Main Menu";
    

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

//Reloads level
    public void Retry()
    {
        loading.FadeTo(SceneManager.GetActiveScene().name);
    }

    //Loads main menu
    public void Menu()
    {
        loading.FadeTo(menu);
    }
}
