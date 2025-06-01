using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint RLTurret;
    public TurretBluePrint freezeTurret;
    public TurretBluePrint treeTurret;
    public TurretBluePrint fastTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("sdakfmldsmf");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectRLTurret()
    {
        Debug.Log("sdakdsadafmldssaasddmf");
        buildManager.SelectTurretToBuild(RLTurret);
    }
    public void SelectFreezeTurret()
    {
        Debug.Log("sdakdsadafmldssaasddmf");
        buildManager.SelectTurretToBuild(freezeTurret);
    }
    public void SelectTreeTurret()
    {
        Debug.Log("sdakdsadafmldssaasddmf");
        buildManager.SelectTurretToBuild(treeTurret);
    }
    public void SelectFastTurret()
    {
        Debug.Log("sdakdsadafmldssaasddmf");
        buildManager.SelectTurretToBuild(fastTurret);
    }

}
