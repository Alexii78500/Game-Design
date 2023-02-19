using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cam : MonoBehaviour
{
    private Vector3 move;
    private bool ended;
    public Manager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        GetComponent<AudioSource>().Play();
        manager.Mute();
    }
}
