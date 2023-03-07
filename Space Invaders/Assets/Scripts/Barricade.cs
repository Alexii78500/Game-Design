using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private float HP = 30;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.Play)
        {
            gameObject.SetActive(true);
            HP = 30;
            return;
        }
        _animator.SetFloat("HP", HP);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        HP--;
        if (HP == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
