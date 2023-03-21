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

    //Selects basic turret
    public void SelectStandardTurret()
    {
        bm.SelectTurretToBuild(standardTurret);
    }
    
    //Selects Missile Launcher
    public void SelectProTurret()
    {
        bm.SelectTurretToBuild(missileLauncher);
    }
    
    //Select Laser Beamer
    public void SelectLaserTurret()
    {
        bm.SelectTurretToBuild(laser);
    }
}
