using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI hscoreText;
    private int highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        highScore = int.Parse(File.ReadAllText("highScore.txt"));
        hscoreText.text = "HighScore: 00" + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
