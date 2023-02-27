using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _delay;
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        //Do not animate the prefab
        if (gameObject.name == "Coin")
            return;

        _delay = 1;
        
        //Sound
        manager.sound.Play(2);

    }

    // Update is called once per frame
    void Update()
    {
        //Do not animate prefab
        if (gameObject.name == "Coin")
        {
            return;
        }
        
        //Animation
        _delay -= Time.deltaTime;
        if (_delay < 0)
        {
            Destroy(gameObject);
        }
        transform.Rotate(2, 0, 0);
        transform.position += new Vector3(0, 0.01f, 0) * _delay;
    }
}
