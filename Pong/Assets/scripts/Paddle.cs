using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    private Rigidbody rb; 
    private Vector3 move = new Vector3(0, 0, 0);
    public Material mat;

    private float r;
    private float b;


    public int speed;

    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        r = mat.color.r;
        b = mat.color.b;
    }

    // Update is called once per frame
    void Update()
    {
        //Fading
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            if (delay > 0)
            {
                if (gameObject.name == "Player 1")
                    mat.color = new Color(r, delay * 2, delay * 2);
                else
                    mat.color = new Color(delay*2, delay * 2, b);
            }
            else
            {
                if (gameObject.name == "Player 1")
                    mat.color = new Color(r, 0, 0);
                else
                    mat.color = new Color(0, 0, b);
            }
        }
    }
    
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector= movementValue.Get<Vector2>();
        move.z = movementVector.y;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        //Enable fading if ball collision
        if (other.gameObject.CompareTag("Ball"))
            pong();
    }
    
    private void FixedUpdate()
    {
        rb.velocity = (move * speed * 2);
    }

    public void pong()
    {
        //Activating fading
        delay = 0.5f;
    }
    
    
}
