using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cam : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPos;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = target.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(targetPos.z, 15, 210));
    }
}
