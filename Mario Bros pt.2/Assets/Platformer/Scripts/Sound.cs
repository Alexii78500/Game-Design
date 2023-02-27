using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioSource[] audio = new AudioSource[8];
    // Start is called before the first frame update
    void Start()
    {
        audio[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(int sound)
    {
        audio[sound].Play();
    }

    public void Mute(int sound)
    {
        audio[sound].Stop();
    }
}
