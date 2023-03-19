using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;
    private readonly Color hoverColorGreen = Color.green;
    private readonly Color hoverColorRed = Color.red;
    private Color startColor;
    private BuildManager bm;

    public GameObject turret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        bm = BuildManager.Instance;
    }

    private void OnMouseDown()
    {
        if (!bm.CanBuild() || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        bm.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (bm.HasMoney() && turret == null)
            rend.material.color = hoverColorGreen;
        
        else if (bm.CanBuild())
            rend.material.color = hoverColorRed;
        
        else
            rend.material.color = Color.gray;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
