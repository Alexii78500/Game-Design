using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public static Transform instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
