using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBP turretToBuild;
    public GameObject buildEffect;

    
    
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
    }

    public bool CanBuild() 
    {
            return turretToBuild != null;
    }
    
    public bool HasMoney()
    {
        return (turretToBuild != null && PlayerStats.Money >= turretToBuild.cost);
    }

    public void BuildTurretOn(Node node)
    {
        //Player broke :(
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        //Subtract cost
        PlayerStats.Money -= turretToBuild.cost;
        
        //Placing turret on node
        var transform1 = node.transform;
        GameObject turret = Instantiate(turretToBuild.prefab, transform1.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        node.turret = turret;
        Instantiate(buildEffect, turret.transform.position, turret.transform.rotation);
    }
}
