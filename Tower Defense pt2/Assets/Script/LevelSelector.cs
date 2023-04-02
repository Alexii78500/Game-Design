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
      if (PlayerPrefs.GetInt("maxLevel", 1) < PlayerPrefs.GetInt("CurrentLevel", 0))
         ResetPrefs();
      int maxLevel = PlayerPrefs.GetInt("maxLevel");
      
      for (int i = 0; i < buttons.Length; i++)
      {
         if (i >= maxLevel)
            buttons[i].interactable = false;
      }
   }

   public void Select(string name)
   {
      loading.FadeTo(name);
   }

   public static void ResetPrefs()
   {
      PlayerPrefs.SetInt("maxLevel", 1);
      PlayerPrefs.SetInt("CurrentLevel", 0);
   }
   
}