using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Aliens : MonoBehaviour
{
    //Variables
    private Vector3 direction;
    private static float speed;
    private float coef;
    public Manager manager;
    private Vector2 pos;



    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        direction = Vector3.left;
        coef = 0.001f;
        pos = transform.localPosition;
    }

    
    
    // Update is called once per frame
    void Update()
    {
        //Game paused
        if (!Manager.Play)
        {
            transform.localPosition = pos;
            return;
        }
        
        
        //Clamping position
        if (transform.position.x > 7f)
        {
            direction = Vector2.left;
            transform.position -= new Vector3(0, 0.1f, 0);
        }
        else if (transform.position.x < -7f)
        {
            direction = Vector3.right;
            transform.position -= new Vector3(0, 0.1f, 0);
        }
        
        //Game Over
        if (transform.localPosition.y < -1.8f)
        {
            Manager.lost = true;
        }

        //Moving
        if (Manager.Hell)
            coef = 0.002f;
        else
            coef = 0.001f;
        
        transform.position += direction * speed * coef;
    }

    public static void SpeedUp()
    {
        speed += 0.1f;
    }

    public static void SpeedReset()
    {
        speed = 5;
    }
}
