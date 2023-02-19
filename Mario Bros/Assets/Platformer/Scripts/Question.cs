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
        if(Input.GetMouseButtonDown(0) && on)
        {
            Ray ray = manager.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rc;
            if (Physics.Raycast(ray, out rc, 100) && rc.transform.position == transform.position)
            {
                GameObject newCoin = Instantiate(coin);
                newCoin.transform.position = transform.position + new Vector3(0.5f, 0.5f, 0);
                mr.material = brown;
                on = false;
            }
        }
    }
}
