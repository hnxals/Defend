using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint millileLauncher;
    public TurretBluePrint LaserBeamer;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(LaserBeamer);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(millileLauncher);
    }

}
