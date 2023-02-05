using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movx;
    private float movy;
    public float speed = 0;
    private int count;
    public TextMeshProUGUI text;
    public TextMeshProUGUI WinText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        WinText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementvalue)
    {
        Vector2 movementvetcor= movementvalue.Get<Vector2>();
        
        movx = movementvetcor.x;
        movy = movementvetcor.y;
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(movx, 0f, movy);
        rb.AddForce(move * speed);
    }
    
    
    
    void SetCountText()
    {
        text.text = "Count: " + count.ToString();
        if (count >= 12)
            WinText.gameObject.SetActive(true);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
