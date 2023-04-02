using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public Loading loading;
    public string menu = "Main Menu";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        GameManager.instance.NextLevel();
    }

    public void Menu()
    {
        GameManager.instance.UnlockNext();
        loading.FadeTo(menu);
    }
}
