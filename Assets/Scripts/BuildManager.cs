using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;
    private Place selectedPlace;

    public TurretUI turretUI;

    void Awake()
    {
        instance = this;
    }

    public bool HaveNoTurret { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeSelectedPlace();
    }

    public void SelectedPlace(Place p)
    {
        if(selectedPlace == p)
        {
            DeSelectedPlace();
            return;
        }
        selectedPlace = p;
        turretToBuild = null;
        turretUI.SetTarget(p);
    }

    public void DeSelectedPlace()
    {
        selectedPlace = null;
        turretUI.Hide();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
