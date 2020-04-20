using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public Color hoverColor = Color.red;
    private Renderer rend;
    private Color originalColor;
    public Vector3 positionAdjust;
         
    [Header("optional")]
    public GameObject currentTurret;
    public TurretBluePrint turretBlueprint;


    BuildManager buildManager;

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionAdjust;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (currentTurret != null)
        {
            buildManager.SelectedPlace(this);
            return;
        }

        if (!buildManager.HaveNoTurret)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }

    void OnMouseEnter()
    {
        if (!buildManager.HaveNoTurret)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = originalColor;
    }

    void BuildTurret (TurretBluePrint bluePrint)
    {
        if (PlayerStatus.money < bluePrint.cost)
        {
            //播放声音，弹出提示
            return;
        }
        PlayerStatus.money -= bluePrint.cost;
        GameObject turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        currentTurret = turret;
        turretBlueprint = bluePrint;

        //弹出提示剩余钱量，播放声音
    }

    public void SellTurret()
    { 
        PlayerStatus.money += turretBlueprint.GetSellValue();

        Destroy(currentTurret);
        turretBlueprint = null;
    }
}
