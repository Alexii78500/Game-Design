using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int wholeSecond;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 101;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            wholeSecond = (int) Mathf.Floor(time);
            text.text = "Time \n   " + wholeSecond;
        }
        else
            Debug.Log("You ran out of time.");
    }
}
