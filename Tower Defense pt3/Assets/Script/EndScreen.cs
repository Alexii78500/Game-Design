using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public Loading loading;
    public string menu = "Main Menu";
    


    //Loads next level
    public void Continue()
    {
        GameManager.instance.NextLevel();
    }

    //Loads main menu
    public void Menu()
    {
        GameManager.instance.UnlockNext();
        loading.FadeTo(menu);
    }
}
