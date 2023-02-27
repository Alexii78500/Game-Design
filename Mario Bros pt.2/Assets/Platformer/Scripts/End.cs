using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Rigidbody rb;

    public Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        manager.sound.Mute(0);
        if (Score.score == 0)
        {
            manager.sound.Play(6);
        }
        else if (Score.score == 4300)
        {
            manager.sound.Play(7);
        }
        else
        {
            manager.sound.Play(4);
        }
        other.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
