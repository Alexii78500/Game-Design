using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public GameObject coin;
    private bool on;
    public Material brown;
    private MeshRenderer mr;
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (on && other.gameObject.CompareTag("Player") && other.transform.position.y < transform.position.y &&
            Mathf.Abs(transform.position.z - other.transform.position.z) < 1.2)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down*5, ForceMode.Impulse);
            manager.score.AddScore(100, true);
            GameObject newCoin = Instantiate(coin);
            newCoin.transform.position = transform.position + new Vector3(0.5f, 0.5f, 0);
            mr.material = brown;
            on = false;
        }
    }
}
