using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Score score;
    public Camera cam;
    public AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
     audio = GetComponent<AudioSource>();
     audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mute()
    {
        audio.volume = 0;
    }
}
