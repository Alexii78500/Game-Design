using System;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    public static float speed;

    //-----------------------------------------------------------------------------
    void Start()
    {
        if (Manager.Hell)
            speed = 12;
        else
            speed = 8;
        Fire();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }
}