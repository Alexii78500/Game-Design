using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plinkoball : MonoBehaviour
{
    private System.Random rng = new();
    public PlinkoManager manager;

    // Start is called before the first frame update
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        //Respawn + random height for start
        transform.position = new Vector3((float)rng.NextDouble()*16-8, 40, 0f);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.name)
        {
            case "Respawn":
            {
                Respawn();
                break;
            }
            
            case "1":
            {
                manager.NewBall();
                Respawn();
                break;
            }
            
            case "2":
            {
                manager.ScoreUp(1);
                Respawn();
                break;
            }
            
            case "3":
            {
                gameObject.SetActive(false);
                Respawn();
                break;
            }
            
            case "4":
            {
                manager.ScoreUp(10);
                Respawn();
                break;
            }
            
            case "5":
            {
                
                gameObject.SetActive(false);
                Respawn();
                break;
            }
            
            case "6":
            {
                manager.ScoreUp(1);
                Respawn();
                break;
            }
            
            case "7":
            {
                manager.valup();
                Respawn();
                break;
            }
            
            case "8":
            {
                manager.NewBall();
                Respawn();
                break;
            }
        }
    }
}
