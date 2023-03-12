using System;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    public static float speed;
    private AudioSource audio;
    public ParticleSystem particles;

    //-----------------------------------------------------------------------------
    void Start()
    {
        particles.Pause();
        audio = GetComponent<AudioSource>();
        if (Manager.Hell)
        {
            particles.Play();
            speed = 12;
        }
        else
            speed = 8;
        Fire();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        audio.Play();
    }
}