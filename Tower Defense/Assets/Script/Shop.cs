using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager bm;
    public TurretBP standardTurret;
    public TurretBP missileLauncher;
    public TurretBP laser;

    private void Start()
    {
        bm = BuildManager.Instance;
    }

    public void SelectStandardTurret()
    {
        bm.SelectTurretToBuild(standardTurret);
    }
    
    public void SelectProTurret()
    {
        bm.SelectTurretToBuild(missileLauncher);
    }
    
    public void SelectLaserTurret()
    {
        bm.SelectTurretToBuild(laser);
    }
}
