using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    private Node target;

    public GameObject UI;

    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;

    public Button upButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = _target.transform.position;
        UI.SetActive(true);
        if (!_target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBp.upgradeCost;
            upButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            upButton.interactable = false;
        }

        if (target == null || target.turretBp == null)
        {
            return;
        }
        sellAmount.text = "$" + _target.turretBp.GetSellAmount();
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.Instance.DeSelectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.Instance.DeSelectNode();
    }
}
