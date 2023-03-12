using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "PlayerBoom")
        {
            return;
        }
        delay = 2;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            Destroy(gameObject);
        }
    }
}
