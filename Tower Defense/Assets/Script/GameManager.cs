using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool ended;

    // Update is called once per frame
    void Update()
    {
        if (ended)
        {
            return;
        }
        if (PlayerStats.Hp <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        ended = true;
        Debug.Log("Game Over");
    }
}
