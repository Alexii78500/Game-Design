using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.0050f, 0);
        if (transform.localPosition.y > 2400)
        {
            SceneManager.LoadScene("Scenes/Menu", LoadSceneMode.Single);
        }
    }
}
