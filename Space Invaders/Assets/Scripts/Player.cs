using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;

    [FormerlySerializedAs("shootingOffset")]
    public Transform shootOffsetTransform;

    public TextMeshProUGUI text;

    private Rigidbody2D rb;
    public Manager manager;

    public static int HP = 3;
    private float delay;

    private Vector2 move;
    private Vector2 pos;

    //-----------------------------------------------------------------------------
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        text.text = "HP: " + HP;
        pos = transform.localPosition;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        //Game Paused
        if (!Manager.Play)
        {
            transform.localPosition = pos;
            rb.velocity = Vector2.zero;
            return;
        }

        //Shooting delay
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

        //Shoot
        else if (Input.GetKey(KeyCode.Space))
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            delay = 0.5f;
            Destroy(shot, 2f);
        }

        //Moving
        rb.velocity = move * 10;
        var position = transform.position;
        position = new Vector3(Mathf.Clamp(position.x, -15f, 15f), position.y,
            position.z);
        transform.position = position;
    }

    void OnMove(InputValue movementValue)
    {
        move = movementValue.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            HP--;
            manager.DisplayHP();
            if (HP == 0)
            {
                manager.HasLost();
            }
        }
    }
}
