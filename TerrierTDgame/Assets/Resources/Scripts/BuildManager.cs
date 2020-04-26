using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {

        instance = this;
    }

    public static string TowerName = "Objects/Turrets/Tower";

    void Update()
    {
        turretToBuild = Resources.Load(TowerName) as GameObject;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        
        return turretToBuild;
    }
}
