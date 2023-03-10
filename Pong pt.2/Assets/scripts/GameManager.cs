using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int p1_score;

    private int p2_score;
    
    public TextMeshPro P1_score;
    
    public TextMeshPro P2_score;

    public Paddle p1;
    public Paddle p2;
    public Ball ball;
    public GameObject bonus;
    private System.Random rng = new();

    public AudioSource music;
    public AudioSource oof;
    public AudioSource pang;

    public Material walls;

    private float fading;
    private float wiggle;
    private float bonusDelay = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Hiding and setting score
        P1_score.color = new Color(P1_score.color.r, P1_score.color.g, P1_score.color.b, 0);
        P2_score.color = new Color(P2_score.color.r, P2_score.color.g, P2_score.color.b, 0);
        p1_score = 0;
        p2_score = 0;
        
        //Launching music
        music.time = 55.2f;
        music.Play();
    }

    
    

    // Update is called once per frame
    void Update()
    {
        //Spawning bonuses
        if (bonusDelay < 0)
        {
            if (rng.Next(0, 500) == 0)
            {
                NewBonus();
                bonusDelay = 2.5f;
            }
        }
        else
            bonusDelay -= Time.deltaTime;
        
        
        //Score fading
        if (fading > 0)
        {
            fading -= Time.deltaTime;
            if (fading > 0)
            {
                P1_score.color = new Color(P1_score.color.r, P1_score.color.g, P1_score.color.b, fading /2);
                P2_score.color = new Color(P2_score.color.r, P2_score.color.g, P2_score.color.b, fading /2);
            }
            else
            {
                P1_score.color = new Color(P1_score.color.r, P1_score.color.g, P1_score.color.b, 0);
                P2_score.color = new Color(P2_score.color.r, P2_score.color.g, P2_score.color.b, 0);
            }
        }

        
        //Wall fading
        if (wiggle < 0)
        {
            wiggle = 0.53f;
            walls.color = Color.green;
        }
        else
        {
            wiggle -= Time.deltaTime;
            walls.color = new Color(0.5f-wiggle, walls.color.g, 0.5f-wiggle);
        }
    }

    public void scored(int player, int val)
    {
        
        //Increment and print score
        if (player == 1)
        {
            p1_score+= val;
            Debug.Log("Player 1 scored");
        }
        else
        {
            p2_score+= val;
            Debug.Log("Player 2 scored");
        }
        
        //Compute Score color
        if (p1_score >= 8)
            P1_score.color = Color.yellow;
        else
            P1_score.color = Color.red;
        if (p2_score >= 8)
            P2_score.color = Color.yellow;
        else
            P2_score.color = Color.blue;
        
        //Display score
        DisplayScore();
    }

    private void DisplayScore()
    {
        //Editing the current score
        P1_score.text = p1_score.ToString();
        P2_score.text = p2_score.ToString();
        
        //Activating the fading
        fading = 2f;
        
        //Print score
        Debug.Log("Score is " + p1_score + " - " + p2_score);

        if (p1_score > 10 || p2_score > 10)
        {
            if (p1_score > 10)
                Debug.Log("Game Over, Left paddle wins!");
            else
                Debug.Log("Game Over, Right paddle wins!");
            Debug.Log("New Game");
            p1_score = 0;
            p2_score = 0;
        }
    }

    public void NewBonus()
    {
        GameObject newBonus = Instantiate(bonus).gameObject;
    }

    public void BonusTrigger(int player, int effect)
    {
        Paddle p;
        if (player == 1)
            p = p1;
        else
            p = p2;

        switch (effect)
        {
            case -1:
            {
                p.slow = true;
                break;
            }
            case 0:
            {
                p.SetSpeed(false);
                break;
            }
            case 1:
            {
                p.SetSpeed(true);
                break;
            }
            case 2:
            {
                p.fast = true;
                break;
            }
                
        }
    }
}
