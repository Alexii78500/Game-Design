using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    private Rigidbody rb; 
    private Vector3 move = new Vector3(0, 0, 0);
    public Material mat;
    private Color def;

    private float r;
    private float b;


    public float speed;
    private float speedref;
    public bool slow;
    public bool fast;
    private float speeddelay = 0f;

    private float delay;

    private AudioSource newAudio;

    public AudioSource oof;

    public AudioSource pang;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        r = mat.color.r;
        b = mat.color.b;
        def = mat.color;
        speedref = speed;
        newAudio = GetComponent<AudioSource>();
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

        if (speeddelay > 0)
        {
            speeddelay -= Time.deltaTime;
            if (speeddelay < 0)
                speed = speedref;
        }


        if (fast)
            mat.color = Color.yellow;
        if (slow)
            mat.color = Color.gray;
        
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
        {
            pong();
            if (fast)
            {
                fast = false;
                Smash();
                pang.Play();
                Camera.StartShake(1f, 0.7f);
            }

            else if (slow)
            {
                slow = false;
                Slow();
                oof.Play();
            }
            else
                newAudio.Play();
        }
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

    public void Smash()
    {
        Ball.fast = true;
        mat.color = def;
    }

    public void Slow()
    {
        Ball.slow = true;
        mat.color = def;
    }

    public void SetSpeed(bool faster)
    {
        if (faster)
            speed *= 1.5f;
        else
            speed /= 2;
        speeddelay = 10;
    }


}
