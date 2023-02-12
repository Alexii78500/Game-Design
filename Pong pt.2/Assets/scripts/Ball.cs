using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    //The current movement of the ball
    private Vector3 move = new Vector3(0, 0, 0);

    public static bool slow;

    public static bool fast;
    private Material mat;
    private MeshRenderer newRenderer;

    //Whether the game is on
    private bool play = true;
    
    //Delays for event activation
    private float wdelay = 0f;
    private float pdelay = 0f;
    private float rdelay;
    
    //Default speed
    public float speed;
    private float speedref;
    
    //Ball value
    private int val = 1;

    private Rigidbody rb;
    public GameManager manager;
    private ParticleSystem particles;
    public ParticleSystem Particles;

    // Start is called before the first frame update
    void Start()
    {
        newRenderer = GetComponent<MeshRenderer>();
        mat = newRenderer.material;
        move.x = speed;
        rb = GetComponent<Rigidbody>();
        
        //Pausing speed particles
        particles = GetComponent<ParticleSystem>();
        particles.Pause();
        Particles.Pause();
        
        //Saving default speed
        speedref = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Moving only if game on
        if (play)
            rb.velocity = move.normalized * speed * 2;
        else
            rb.velocity = new Vector3(0f, 0f, 0f);

        if (slow)
        {
            rb.velocity = new Vector3(rb.velocity.x / 2, 0, 0);
            mat.color = Color.cyan;
        }
        else if (fast)
        {
            rb.velocity = new Vector3(rb.velocity.x * 2, 0, rb.velocity.z);
            mat.color = Color.red;
        }
        
        
        //Managing delays
        if (wdelay > 0)
            wdelay -= Time.deltaTime;
        
        if (pdelay > 0)
            pdelay -= Time.deltaTime;
        
        if (rdelay > 0)
            rdelay -= Time.deltaTime;
        else
            play = true;

        //Activating particles if fast
        if (speed > 12)
        {
            Particles.Play();
            particles.Play();
            val = 3;
        }
        
        if (Math.Abs(transform.position.x) > 100)
            Respawn(1);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        //Ball hits paddle
        if (other.gameObject.CompareTag("Paddle") && pdelay <= 0)
        {
            slow = false;
            fast = false;
            mat.color = Color.yellow;

            speed *= 1.05f;
            move.x *= -1;
            pdelay += 0.1f;
            move.z = (transform.position.z - other.transform.position.z)*1.3f;
        }
        
        //Ball hits wall
        if (other.gameObject.CompareTag("Wall") && wdelay <= 0)
        {
            move.z *= -1;
            wdelay = 0.2f;
        }
        
        //Ball hits goal
        if (other.gameObject.CompareTag("Goal"))
        {
            Scored(other);
        }
    }

    private void Scored(Collision goal)
    {
        //Player 2 scored
        if (goal.gameObject.name == "Goal 1")
        {
            manager.scored(2, val);
            Respawn(1);
        }
        //Player 1 scored
        else
        {
            manager.scored(1, val);
            Respawn(2);
        }
    }

    private void Respawn(int player)
    {
        //Stopping particles
        particles.Stop();
        Particles.Stop();

        //Pausing game for 1.5s
        play = false;
        rdelay = 1.5f;
        
        //Speed back to default
        speed = speedref;
        
        //Ball value back to default
        val = 1;

        //Random angle for respawn
        System.Random rng = new System.Random();
        move.z = (float) rng.NextDouble() * 14 - 7;
        
        //Respawn side and direction
        int xpos;
        if (player == 1)
        {
            move.x = -speed;
            xpos = 5;
        }
        else
        {
            move.x = speed;
            xpos = -5;
        }
        
        //Respawn + random height for start
        transform.position = new Vector3(xpos, 0.5f, (float)rng.NextDouble() * 16 - 8);
    }
    
}
