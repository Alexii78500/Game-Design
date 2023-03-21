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
        //Cursor hovering UI
        if (!bm.CanBuild() || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        //Turret already on node
        if (turret != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        bm.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        //Cursor hovering UI
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        //Turret can be built
        if (bm.HasMoney() && turret == null)
            rend.material.color = hoverColorGreen;
        
        //Can not build on node
        else if (bm.CanBuild())
            rend.material.color = hoverColorRed;
        
        //No turret selected
        else
            rend.material.color = Color.gray;
    }

    private void OnMouseExit()
    {
        //Back to white
        rend.material.color = startColor;
    }
}
