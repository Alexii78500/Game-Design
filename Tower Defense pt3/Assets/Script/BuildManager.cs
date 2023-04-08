using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBP turretToBuild;
    private Node SelectedNode;
    public NodeUI nodeUI;
    public GameObject buildEffect;
    public GameObject sellEffect;

    
    
    // - Uses static context to access an instance of the class
    // - Refuses to elaborate
    public static BuildManager Instance;
    private void Awake()
    {
        Instance = this;
    }


    public void SelectTurretToBuild(TurretBP turret)
    {
        turretToBuild = turret;
        SelectedNode = null;
        
        //Hides upgrade UI
        nodeUI.Hide();
    }

    public void SelectNode(Node nodeToSelect)
    {
        //Clicking on the same node
        if (SelectedNode == nodeToSelect)
        {
            DeSelectNode();
            return;
        }
        SelectedNode = nodeToSelect;
        turretToBuild = null;

        //Shows upgrade UI
        nodeUI.SetTarget(nodeToSelect);
    }

    public void DeSelectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }

    public bool CanBuild() 
    {
            return turretToBuild != null;
    }
    
    public bool HasMoney()
    {
        return (turretToBuild != null && PlayerStats.Money >= turretToBuild.cost);
    }

    public TurretBP GetTurretToBuild()
    {
        return turretToBuild;
    }
}
