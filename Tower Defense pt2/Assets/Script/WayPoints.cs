using System;
using System.Collections;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] Waypoints;

    private void Awake()
    {
        Waypoints = new Transform[transform.childCount];
        for (int i = 0; i < Waypoints.Length; i++)
        {
            Waypoints[i] = transform.GetChild(i);
        }
    }
}
