using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.position.y < transform.position.y &&
            Mathf.Abs(transform.position.z - other.transform.position.z) < 1.2)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down*5, ForceMode.Impulse);
            manager.sound.Play(1);
            manager.score.AddScore(100, false);
            Destroy(gameObject);
        }
    }
}
