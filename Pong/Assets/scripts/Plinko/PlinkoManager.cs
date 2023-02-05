using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlinkoManager : MonoBehaviour
{

    private int Score = 0;
    private int val = 100;
    public Plinkoball ball;
    public TextMeshPro text;
    
    // Start is called before the first frame update
    void Start()
    {
        NewBall();
        NewBall();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Score.ToString();
    }

    public void NewBall()
    {
        GameObject newball = Instantiate(ball).gameObject;
    }

    public void ScoreUp(int i)
    {
        Score += val*i;
    }

    public void valup()
    {
        val+=100;
    }
}
