using System;
using Mono.Cecil;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    //-----------------------------------------------------------------------------
    public int value;
    public GameObject bulletPrefab;

    public delegate void EnemyDestroyed(int value);

    public static event EnemyDestroyed OnEnemyDestroyed;
    private System.Random _rng = new();
    private int difficulty;


    private void Start()
    {
        Manager.OnRespawn += Respawn;
    }

    void Update()
    {
        //Game paused
        if (!Manager.Play)
            return;
        
        //Hell mode
        difficulty = Manager.Hell ? 3 : 1;

        //RNG firing
        if (_rng.Next(0, 3000 / difficulty) == 69)
        {
            Fire();
        }
    }
    
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Destroy(bullet, 4f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy hit by bullet
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject); // destroy bullet
            OnEnemyDestroyed.Invoke(value);
            gameObject.SetActive(false);
        }
    }

    
    void Respawn()
    {
        gameObject.SetActive(true);
    }
}
