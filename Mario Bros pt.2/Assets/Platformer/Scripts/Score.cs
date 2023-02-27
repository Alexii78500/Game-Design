using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _coinText;
    public static int score;

    private static int _coins;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int s, bool coin)
    {
        score += s;
        _scoreText.text = "MARIO\n000" + score;
        if (coin)
        { 
            _coins += 1;
            _coinText.text = "x 0" + _coins;
        }

    }
}
