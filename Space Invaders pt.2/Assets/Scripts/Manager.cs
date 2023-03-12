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
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //Variables
    public static int score;
    private int killed;
    public float time;
    public static bool Play = true;
    public static bool Hell;
    public static bool lost = false;
    
    //Components
    public Animator planeAnimator;
    public Animator alienAnimator;
    public Sound sound;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HPText;
    public GameObject boss;
    public Transform spawn;
    private System.Random rng;

    //Events
    public delegate void Respawn();
    public static event Respawn OnRespawn;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rng = new System.Random();
        Enemy.OnEnemyDestroyed += OnEnemyDestroyed;
        Boss.OnBossDestroyed += OnEnemyDestroyed;
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
        killed = 0;

        //Start Game
        sound.Play(0);
        Play = true;
    }

    //Enemy got shot
    private void OnEnemyDestroyed(int value)
    {
        sound.Play(3);
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
            return;
        }
        
        time += Time.deltaTime;
        if (time > 182)
        {
            HasLost();
        }
        Hell = time is > 15.5f and < 36 || time is > 80f and < 101 || time is > 149f and < 180;
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
        //Mute music
        sound.Mute(0);
        
        //Manage highScore
        var highScore = File.ReadAllText("highScore.txt");
        var str = highScore;
        if (score > int.Parse(highScore))
            str = score.ToString();
        File.WriteAllText("highScore.txt", str);
        
        sound.Play(2);
        Play = false;

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        //Stop Game
        SceneManager.LoadScene("Scenes/Credits", LoadSceneMode.Single);
    }
    
    void DisplayScore()
    {
        scoreText.text = "00" + score;
    }

    void NewWave()
    {
        if (lost)
        {
            HasLost();
        }
        
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
