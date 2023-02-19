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
        if (gameObject.name == "Coin")
            return;
        manager.score.AddScore(100);
        _delay = 1;
 GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Coin")
        {
            return;
        }
        _delay -= Time.deltaTime;
        if (_delay < 0)
        {
            Destroy(gameObject);
        }
        transform.Rotate(2, 0, 0);
        transform.position += new Vector3(0, 0.01f, 0) * _delay;
    }
}
