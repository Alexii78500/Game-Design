using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    //Variables
    private Rigidbody rb;
    public Animator animator;
    public Manager manager;

    private float _acceleration;
    private float _jumpForce = 30f;
    private float jumpBoostRef;
    private float _jumpBoost = 30f;
    private float coyote = 0.2f;
    private float coyoteCounter;
    private bool nudge;
    
    public Collider col;
    public GameObject Mario;
    private float halfHeight;

    private float maxSpeed =3.5f;
    private float Speed;
    private Vector3 move;
    private Vector3 gravity;
    private bool jump;

    public bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        halfHeight = col.bounds.extents.y + 0.03f;
        jumpBoostRef = _jumpBoost;
        animator.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Death
        if (transform.position.y < -5)
        {
            manager.sound.Mute(0);
            manager.sound.Play(5);
            gameObject.SetActive(false);
        }
        
        //Run
        if (Input.GetKey(KeyCode.LeftShift) && move.z != 0)
        {
            maxSpeed = 7;
            if (!_isGrounded)
                Mario.transform.position = transform.position - new Vector3(0, 0.5f, 0);
            else
                Mario.transform.position = transform.position - new Vector3(0, 1f, 0);

        }
        else
        {
            maxSpeed = 3.5f;
            Mario.transform.position = transform.position - new Vector3(0, 1f, 0);
        }
        
        
        
        //Acceleration
        if (move != new Vector3())
        {
            if (Mathf.Abs(Speed) < Mathf.Abs(maxSpeed))
                _acceleration = Mathf.Clamp(_acceleration + 0.005f, 0, 1);
            else
                _acceleration = Mathf.Clamp(_acceleration - 0.005f, 0, 1);
        }
        //Different acceleration whether grounded
        else
            _acceleration = 0;
        Speed = move.z * _acceleration * 7;
        rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y, -5, 5), Speed);
        animator.SetFloat("Speed", Math.Abs(rb.velocity.z));

        //Rotation
        if (rb.velocity.z > 0.1f)
            transform.rotation = Quaternion.identity;
        else if (rb.velocity.z < -0.1f)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        
        //Grounded
        _isGrounded = Physics.Raycast(transform.position - new Vector3(0, 0, 0.35f), Vector3.down, halfHeight+0.3f)
            || Physics.Raycast(transform.position + new Vector3(0, 0, 0.35f), Vector3.down, halfHeight+0.3f)
            || Physics.Raycast(transform.position, Vector3.down, halfHeight+0.3f);
        
        animator.SetBool("IsGrounded", !_isGrounded);
        
        //Coyote
        if (_isGrounded)
        {
            coyoteCounter = coyote;
            nudge = true;
        }
        else
            coyoteCounter -= Time.deltaTime;
        
        
        //Nudging
        if (!_isGrounded && nudge)
        {
            bool right = Physics.Raycast(transform.position - new Vector3(0, 0, 0.1f), Vector3.up, halfHeight + 0.3f);
            bool left = Physics.Raycast(transform.position + new Vector3(0, 0, 0.1f), Vector3.up, halfHeight + 0.3f);
            if (left != right)
            {
                if (left)
                    transform.position -= new Vector3(0,0, 0.35f);
                else
                    transform.position += new Vector3(0, 0, 0.35f);
                nudge = false;
            }
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && coyoteCounter > 0)
        {
            manager.sound.Play(3);
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            jump = true;
            _jumpBoost = jumpBoostRef;
        }
            //Holding
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            rb.AddForce(Vector3.up * _jumpBoost, ForceMode.Force);
            _jumpBoost -= 0.1f;
            if (_jumpBoost < 0)
            {
                jump = false;
            }
            gravity += new Vector3(0, 0.15f, 0);
        }
        else
            jump = false;

        //Reset coyote
        if (Input.GetKeyUp(KeyCode.Space))
            coyoteCounter = 0;
        
        //Gravity
        if (!_isGrounded)
        {
            gravity -= new Vector3(0, 0.15f, 0);
            gravity = new Vector3(gravity.x, Mathf.Clamp(gravity.y, -50, 30), gravity.z);
        }
        else
            gravity = new Vector3(0, -1, 0);
        rb.AddForce(gravity, ForceMode.Force); 
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        move.z = movementVector.x;
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.CompareTag("Brick") || other.gameObject.CompareTag("Question")) && other.transform.position.y > transform.position.y &&
            Mathf.Abs(transform.position.z - other.transform.position.z) < 1.2)
        {
            jump = false;
        }
    }
}
    
    
