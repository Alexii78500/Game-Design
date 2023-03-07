using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Manager manager;
    public TextMeshProUGUI hscoreText;
    public TextMeshProUGUI scoreText;
    private int highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        Toggle(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            manager.StartGame();
            Toggle(false);
        }
    }

    public void Toggle(bool on)
    {
        gameObject.SetActive(on);
        if (on)
        {
            highScore = int.Parse(File.ReadAllText("highScore.txt"));
            hscoreText.text = "HighScore: 00" + highScore;
            scoreText.text = "Score: 00" + Manager.score;
        }
    }
}
