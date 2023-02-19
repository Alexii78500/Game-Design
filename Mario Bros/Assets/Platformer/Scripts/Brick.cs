using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public Manager manager;
    public AudioSource newAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = manager.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rc;
            if (Physics.Raycast(ray, out rc, 100) && rc.transform.position == transform.position)
            {
                newAudio.Play();
                Destroy(gameObject);
            }
        }
    }
}
