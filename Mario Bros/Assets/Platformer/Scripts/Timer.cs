using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int wholeSecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wholeSecond = (int) Mathf.Floor(Time.realtimeSinceStartup);
        text.text = "Time \n   " + (502 - wholeSecond);
    }
}
