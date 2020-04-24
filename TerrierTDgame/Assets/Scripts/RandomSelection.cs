using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomSelection : MonoBehaviour
{
    [SerializeField] Text SelectionTimerText;
    public GameObject firstTower;
    public GameObject secondTower;
    public GameObject thirdTower;
    private float selectionTimer = 10f;
    public GameObject SelectionUI;
           
    void Update()
    {
        WaveSpawner.spawnchecker = 0;
        Debug.Log("Selection is called ");
        selectionTimer -= Time.deltaTime;
        SelectionTimerText.text = Mathf.Round(selectionTimer).ToString();
        if (selectionTimer <= 0)
        {
            //select a random tower and exit the scene
             
            selectionTimer = 10f;
            WaveSpawner.spawnchecker = 1;
            Debug.Log("Setting bool");
            SelectionUI.SetActive(false);
        }
    }

    private int RandNum()
    {
        int RandomNumber = Random.Range(1, 1000);
        return RandomNumber;
    }

    public int TowerSelect()
    {
        // Just for an example, Tower types are denoted from type 1 to type 3
        int TowerNumber = RandNum();
        if (TowerNumber > 0 && TowerNumber <= 500) //It's like saying this type of tower has 500 in 1000 chance of getting
        {                                            // Or 50% chance
            return 1;

        }

        if (TowerNumber > 500 && TowerNumber <= 800) //It's like saying this type of tower has 300 in 1000 chance of getting
        {                                            // Or 30% chance
            return 2;
        }

        else                    //It's like saying this type of tower has 200 in 1000 chance of getting
        {                                            // Or 20% chance
            return 3;
        }

    }

    void TowerList()
    {
        int firsttower = TowerSelect(), secondtower = TowerSelect(), thirdtower = TowerSelect();
        while (secondtower == firsttower || secondtower == thirdtower)
        {
            secondtower = TowerSelect();
        }

        while (thirdtower == firsttower || thirdtower == secondtower)
        {
            thirdtower = TowerSelect();
        }

        // And then scripts to select prefabs buildManager()
    }

 
    

}