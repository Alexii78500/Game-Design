using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int Alive = 0;
    
    [Header("Wave Settings")]
    private float timer = 3f;

    public Wave[] waves;
    
    private float countDown;
    private int waveNumber;

    [Header("Unity")]
    public Transform spawn;
    public TextMeshProUGUI waveCDText;


    
    

    private void Start()
    {
        Alive = 0;
    }


    // Update is called once per frame
    void Update()
    {
        //Alive enemies left
        if (Alive > 0)
        {
            return;
        }

        if (waveNumber >= waves.Length)
        {
            GameManager.instance.WinLevel();
            enabled = false;
        }
        
        
        //End of cd
        if (countDown <= 0f)
        {
            countDown = timer;
            StartCoroutine(SpawnWave());
            return;
        }
        
        //Manage countdown
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);
        waveCDText.text = $"{countDown:00.000}";



    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveNumber];

        Alive = wave.Count;
        
        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.EnemyPrefab);
            yield return new WaitForSeconds(1/wave.Rate);
        }
        waveNumber++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawn.position, spawn.rotation);
    }
}
