using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;

    private Renderer rend;
    private Color StartColor;

    void Start () 
        {
            rend = GetComponent<Renderer>();
            StartColor = rend.material.color;

        }

    void OnMouseDown ()
    {
        if (turret != null)
        {
            Turret currentTurret = turret.GetComponent<Turret>(); //This is the currently placed tower
            GameObject selectedTurret = BuildManager.instance.GetTurretToBuild();
            Turret selectedT = selectedTurret.GetComponent<Turret>(); //This is the prefab tower selected in between rounds

            if (currentTurret.getId() == selectedT.getId() && currentTurret.level <= 2) {
                currentTurret.Upgrade();
            }
            if (currentTurret.getId() == selectedT.getId() && currentTurret.level > 2) {
                Debug.Log("Cannot Upgrade any further");
            }

            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position +positionOffset, transform.rotation);
        rend.enabled = false;
    }
    
   void OnMouseEnter ()
   {
       rend.material.color = hoverColor;
   }

   void OnMouseExit ()
   {
       rend.material.color = StartColor;
   }

}
