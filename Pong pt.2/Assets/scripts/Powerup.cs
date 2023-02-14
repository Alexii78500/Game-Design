using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private System.Random rng = new();
    public int type;
    public  Rigidbody rb;
    public GameManager manager;
    
    public Material mat;

    private Vector3 velocity = new (10, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //Type
        type = rng.Next(-1, 3);
        
        //Setting color
        if (type > 0)
        {
            mat.color = Color.green;
        }
        else
        {
            {
                mat.color = Color.red;
            }
        }

        //Setting position and direction
        transform.position = new Vector3(0, 0.5f, rng.Next(-8, 8));
        if (rng.Next(0, 2) == 0)
        {
            velocity *= -1;
        }

        if (gameObject.name == "PowerUp")
        {
            velocity *= 0;
            transform.position = new Vector3(0, -5, 0);
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
        transform.Rotate(new Vector3(30, 40, 50));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            Destroy(gameObject);
            if (other.gameObject.name == "Player 1")
                manager.BonusTrigger(1, type);
            else
                manager.BonusTrigger(2, type);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            Destroy(gameObject);
        }
    }
}
