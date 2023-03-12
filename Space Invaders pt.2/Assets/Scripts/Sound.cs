using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource[] audio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(int track)
    {
        if (audio[track] != null)
        {
            audio[track].Play();
        }
    }
    
    public void Mute(int track)
    {
        audio[track].Stop();
    }
}
