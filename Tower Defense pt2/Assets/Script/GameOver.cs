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
    public Scene Game;
    public Loading loading;
    string menu = "Main Menu";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        loading.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        loading.FadeTo(menu);
    }
}
