using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private float HP = 10;
    private Animator _animator;
    private AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Manager.OnRespawn += ResetHP;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.Play)
        {
            gameObject.SetActive(true);
            HP = 10;
            return;
        }
        _animator.SetFloat("HP", HP);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        audio.Play();
        HP--;
        if (HP == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void ResetHP()
    {
        if (this != null)
        {
            gameObject.SetActive(true);
            HP = 10;
        }
    }
}
