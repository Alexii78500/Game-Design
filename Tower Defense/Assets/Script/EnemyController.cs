using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float HP = 30;
    public int money = 50;
    public Transform deathEffect;
    private EnemyMove _enemyMove;

    private void Start()
    {
        _enemyMove = GetComponent<EnemyMove>();
    }


    public void TakeDamage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity).gameObject, 2f); 
        PlayerStats.Money += money;
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        _enemyMove.Slow(pct);
    }
}
