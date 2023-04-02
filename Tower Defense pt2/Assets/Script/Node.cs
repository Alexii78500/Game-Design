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

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBP turretBp;
    [HideInInspector] public bool isUpgraded;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        bm = BuildManager.Instance;
    }

    private void OnMouseDown()
    {
        //Cursor hovering UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        //Turret already on node
        if (turret != null)
        {
            bm.SelectNode(this);
            return;
        }

        if (!bm.CanBuild())
        {
            return;
        }

        BuildTurret(bm.GetTurretToBuild());
    }

    void BuildTurret(TurretBP bp)
    {
        //Player broke :(
        if (PlayerStats.Money < bp.cost)
        {
            return;
        }

        //Subtract cost
        PlayerStats.Money -= bp.cost;

        turretBp = bp;
        
        //Placing turret on node
        var transform1 = transform;
        turret = Instantiate(bp.prefab, transform1.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Instantiate(bm.buildEffect, turret.transform.position, turret.transform.rotation);
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

    public void UpgradeTurret()
    {
        //Player broke :(
        if (PlayerStats.Money < turretBp.upgradeCost || isUpgraded)
        {
            return;
        }

        //Subtract cost
        PlayerStats.Money -= turretBp.upgradeCost;
        isUpgraded = true;
        Destroy(turret);
        
        //Placing turret on node
        var transform1 = transform;
        turret = Instantiate(turretBp.upgradedPrefab, transform1.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Instantiate(bm.buildEffect, turret.transform.position, turret.transform.rotation);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBp.GetSellAmount();
        Destroy(turret);
        turretBp = null;
        isUpgraded = false;
        
        Instantiate(bm.sellEffect, turret.transform.position, turret.transform.rotation);
    }
}
