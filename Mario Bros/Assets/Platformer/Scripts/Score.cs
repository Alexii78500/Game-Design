using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _coinText;
    private static int _score;

    private static int _coins;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int s)
    {
        _score += s;
        _scoreText.text = "MARIO\n000" + _score;
        _coins += 1;
        _coinText.text = "x 0" + _coins;

    }
}
