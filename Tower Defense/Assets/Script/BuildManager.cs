using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    private TurretBP turretToBuild;
    public GameObject buildEffect;

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
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        
        var transform1 = node.transform;
        GameObject turret = Instantiate(turretToBuild.prefab, transform1.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        node.turret = turret;
        Instantiate(buildEffect, turret.transform.position, turret.transform.rotation);
    }
}
