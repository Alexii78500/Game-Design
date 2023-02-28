using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
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
        if (transform.position.y < -5)
        {
            rb.AddForce(Vector3.up *2.6f, ForceMode.Impulse);
        } 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            manager.sound.Mute(0);
            manager.sound.Play(5);
        }
    }
}
