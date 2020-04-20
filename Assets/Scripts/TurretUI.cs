using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private Place target;
    public GameObject ui;
    public Text sellValue;

    public void SetTarget(Place place)
    {
        target = place; 
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
        sellValue.text = "+$" + target.turretBlueprint.GetSellValue().ToString();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeSelectedPlace();
    }
}
