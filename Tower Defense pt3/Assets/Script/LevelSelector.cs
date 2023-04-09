using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
   public Loading loading;
   public Button[] buttons;

   private void Start()
   {
      //Make sure level progress is not glitched
      if (PlayerPrefs.GetInt("maxLevel", 1) < PlayerPrefs.GetInt("CurrentLevel", 0))
         ResetPrefs();
      
      int maxLevel = PlayerPrefs.GetInt("maxLevel");
      
      //Disable all locked levels
      for (int i = 0; i < buttons.Length; i++)
      {
         if (i >= maxLevel)
            buttons[i].interactable = false;
      }
   }

   //Reset the progress
   public static void ResetPrefs()
   {
      PlayerPrefs.SetInt("maxLevel", 1);
      PlayerPrefs.SetInt("CurrentLevel", 0);
   }
   
}
