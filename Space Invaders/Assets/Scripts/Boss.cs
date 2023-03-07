using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Vector3 direction;
    private System.Random _rng;
    public GameObject bulletPrefab;
    public delegate void BossDestroyed(int value);
    public static event BossDestroyed OnBossDestroyed;

    private int value = 300;
    private int HP = 3;
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        _rng = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        //Clamping position
        if (transform.position.x > 9f)
        {
            direction = Vector2.left;
        }
        else if (transform.position.x < -9f)
        {
            direction = Vector3.right;
        }

        transform.position += direction * speed * 0.001f;
        
        //RNG firing
        if (_rng.Next(0, 1000) == 69)
        {
            Fire();
        }
    }
    
    void Fire()
    {
        var position = transform.position;
        GameObject bullet1 = Instantiate(bulletPrefab, position, Quaternion.identity);
        GameObject bullet2 = Instantiate(bulletPrefab, position + new Vector3(1, 0, 0), Quaternion.Euler(-20, 0, 0));
        GameObject bullet3 = Instantiate(bulletPrefab, position - new Vector3(1, 0, 0), Quaternion.Euler(20, 0, 0));
        Destroy(bullet1, 4f);
        Destroy(bullet2, 4f);
        Destroy(bullet3, 4f);
    }
        
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            HP--;
            Destroy(collision.gameObject); // destroy bullet
            if (HP == 0)
            {
                OnBossDestroyed.Invoke(value);
                gameObject.SetActive(false);
            }
        }
    }
    
    
}
