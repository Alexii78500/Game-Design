using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float HP = 30;
    private float maxHp;
    public int money = 50;
    public Transform deathEffect;
    private EnemyMove _enemyMove;

    [Header("Unity Stuff")] public Image healthBar;


    private void Start()
    {
        _enemyMove = GetComponent<EnemyMove>();
        maxHp = HP;
        deathEffect.GetComponent<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;
    }


    public void TakeDamage(float damage)
    {
        HP -= damage;
        healthBar.fillAmount = HP / maxHp;

        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        WaveSpawner.Alive--;
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity).gameObject, 2f); 
        PlayerStats.Money += money;
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        _enemyMove.Slow(pct);
    }
}
