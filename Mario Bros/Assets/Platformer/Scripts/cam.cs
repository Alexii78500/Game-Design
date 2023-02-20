using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cam : MonoBehaviour
{
    private Vector3 move;
    private bool ended;
    public Manager manager;

    public AudioSource a1;
    public AudioSource a2;
    public AudioSource a3;

    public Material filter;
    // Start is called before the first frame update
    void Start()
    {
        filter.color = new Color(0, 0, 0, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(move.z > 0 && transform.position.z > 210) && !(move.z < 0 && transform.position.z < 15))
            transform.position += move * 0.1f;
        if (transform.position.z > 190 && !ended)
        {
            end();
            ended = true;
        }
    }
    
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector= movementValue.Get<Vector2>();
        move.z = movementVector.x;
    }

    void end()
    {
        if (Score.score == 0)
        {
            a2.Play();
            filter.color = new Color(1, 0, 0, 0.3f);
        }
        else if (Score.score == 1300)
        {
            a3.Play();
            filter.color = new Color(0, 1, 0, 0.3f);
        }
        else
        {
            a1.Play();
        }
        manager.Mute();
    }
}
