using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        ui.SetActive(true);

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
        }


        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount().ToString();


    }

    public void Hide()
    {
        target = null;
        ui.SetActive(false); 
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
