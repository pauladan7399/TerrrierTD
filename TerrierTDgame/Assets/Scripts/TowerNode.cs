using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerNode : MonoBehaviour
{
    public GameObject TowerMenuUI;
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;

    private Renderer rend;
    private Color StartColor;

    void Start () 
        {
            rend = GetComponent<Renderer>();
            StartColor = rend.material.color;
            TowerMenuUI.SetActive(false);

        }

    void OnMouseDown ()
    {

        TowerMenuUI.SetActive(true);
        if (turret != null)
        {
            Debug.Log("Can't Build Here!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position +positionOffset, transform.rotation);
        Destroy(gameObject);
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
