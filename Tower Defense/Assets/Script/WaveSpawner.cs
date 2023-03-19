using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public EnemyController enemyPrefab;
    public Transform spawn;
    public TextMeshProUGUI waveCDText;


    private float timer = 5f;
    private float countDown = 2f;
    private int waveNumber;
    

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timer;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);

        waveCDText.text = $"{countDown:00.000}";
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawn.position, spawn.rotation);
    }
}
