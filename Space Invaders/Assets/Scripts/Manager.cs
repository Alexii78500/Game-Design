using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class Manager : MonoBehaviour
{
    //Variables
    public static int score;
    private int killed;
    public float time;
    public static bool Play;
    public static bool Hell;
    
    //Components
    public Animator planeAnimator;
    public Animator alienAnimator;
    private AudioSource audio;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HPText;
    public GameObject boss;
    public Transform spawn;
    private System.Random rng;
    public Menu menu;

    //Events
    public delegate void Respawn();
    public static event Respawn OnRespawn;
    
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rng = new System.Random();
        DisplayScore();
        audio = GetComponent<AudioSource>();
        Enemy.OnEnemyDestroyed += OnEnemyDestroyed;
        Boss.OnBossDestroyed += OnEnemyDestroyed;
        if(Play)
            StartGame();
    }

    //Starts a new game
    public void StartGame()
    {
        //Reset score
        score = 0;
        DisplayScore();
        Player.HP = 3;
        DisplayHP();
        time = 0;
        
        //Respawn aliens
        OnRespawn.Invoke();
        killed = 0;
        Aliens.SpeedReset();
        
        //Start Game
        audio.Play();
        Play = true;
    }

    //Enemy got shot
    private void OnEnemyDestroyed(int value)
    {
        Aliens.SpeedUp();
        killed++;
        
        //Score Up
        score += value;
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        //Game Paused
        if (!Play)
        {
            audio.Stop();
            return;
        }
        
        time += Time.deltaTime;
        Hell = time is > 16f and < 36 || time is > 81f and < 101 || time is > 149f and < 180;
        time = time % 190;
        planeAnimator.SetBool("Hell", Hell);
        alienAnimator.SetBool("Hell", Hell);

        //All aliens killed
        if (killed > 24)
        {
            NewWave();
        }
    }

    //Player has lost
    public void HasLost()
    {
        //Manage highScore
        var highScore = File.ReadAllText("highScore.txt");
        var str = highScore;
        if (score > int.Parse(highScore))
            str = score.ToString();
        File.WriteAllText("highScore.txt", str);
        
        //Stop Game
        Play = false;
        menu.Toggle(true);
    }
    
    void DisplayScore()
    {
        scoreText.text = "00" + score;
    }

    void NewWave()
    {
        //Reset aliens and speed
        OnRespawn.Invoke();
        killed = 0;
        Aliens.SpeedReset();
        Player.HP++;
        DisplayHP();

        //Boss spawn
        if (rng.Next(0, 4) == 0)
        {
            Instantiate(boss, spawn.position, Quaternion.identity);
            killed--;
        }
    }

    public void DisplayHP()
    {
        HPText.text = "HP: " + Player.HP;
    }
}
