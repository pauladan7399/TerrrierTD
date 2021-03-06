﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomSelection : MonoBehaviour
{
    [SerializeField] Text SelectionTimerText;
    public GameObject Tower1; // Citgo
    public GameObject Tower2; // WarrenTower
    public GameObject Tower3; // Photonics
    public GameObject Tower4; // PandaExpress
    public GameObject Tower5; // Kenmore
    public GameObject Tower6; // Fenway
    public GameObject Tower7; // BrownStonw
    public GameObject Tower8; // Agganis

    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;
    public Sprite Sprite7;
    public Sprite Sprite8;

    public Button Button1;
    public Button Button2;
    public Button Button3;


    private int firsttower;
    private int secondtower;
    private int thirdtower;

    private float selectionTimer = 10f;
    public GameObject SelectionUI;
    public GameObject BuildTower;

    void OnEnable()
    {
        TowerList();
        SetUpButtonImage(ref Button1, firsttower);
        SetUpButtonImage(ref Button2, secondtower);
        SetUpButtonImage(ref Button3, thirdtower);
    }


    void Update()
    {
        Debug.Log("Selection is called ");

        selectionTimer -= Time.deltaTime;
        SelectionTimerText.text = Mathf.Round(selectionTimer).ToString();
        if (selectionTimer <= 0)
        {
            //select a random tower and exit the scene


            WaveSpawner.spawnchecker = 1;
            Debug.Log("Setting bool");
            SelectionUI.SetActive(false);
            selectionTimer = 10f;
        }
    }

    // ============================================================================================================

    private int RandNum()
    {
        int RandomNumber = Random.Range(1, 1000);
        return RandomNumber;
    }

    public int TowerSelect()
    {
        // Just for an example, Tower types are denoted from type 1 to type 3
        int TowerNumber = RandNum();
        if (TowerNumber > 0 && TowerNumber <= 200) //It's like saying this type of tower has 500 in 1000 chance of getting
        {                                            // Or 50% chance
            return 1;

        }

        if (TowerNumber > 200 && TowerNumber <= 300) //It's like saying this type of tower has 300 in 1000 chance of getting
        {                                            // Or 30% chance
            return 2;
        }


        if (TowerNumber > 300 && TowerNumber <= 400) //It's like saying this type of tower has 300 in 1000 chance of getting
        {                                            // Or 30% chance
            return 3;
        }


        if (TowerNumber > 400 && TowerNumber <= 500) //It's like saying this type of tower has 300 in 1000 chance of getting
        {                                            // Or 30% chance
            return 4;
        }


        if (TowerNumber > 500 && TowerNumber <= 600) //It's like saying this type of tower has 300 in 1000 chance of getting
        {                                            // Or 30% chance
            return 5;
        }


        if (TowerNumber > 700 && TowerNumber <= 800) //It's like saying this type of tower has 300 in 1000 chance of getting
        {                                            // Or 30% chance
            return 6;
        }

        if (TowerNumber > 800 && TowerNumber <= 900) //It's like saying this type of tower has 300 in 1000 chance of getting
        {                                            // Or 30% chance
            return 7;
        }

        else                    //It's like saying this type of tower has 200 in 1000 chance of getting
        {                                            // Or 20% chance
            return 8;
        }

    }

    void TowerList()   // Comparing them before putting them on selection
    {
        firsttower = TowerSelect();
        secondtower = TowerSelect();
        thirdtower = TowerSelect();
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

    void SetUpButtonImage(ref Button Butt, int towernum) // function to setup the button
    {
        switch (towernum)
        {
            case 1:
                Butt.GetComponent<Image>().sprite = Sprite1;
                break;
            case 2:
                Butt.GetComponent<Image>().sprite = Sprite2;
                break;
            case 3:
                Butt.GetComponent<Image>().sprite = Sprite3;
                break;
            case 4:
                Butt.GetComponent<Image>().sprite = Sprite4;
                break;
            case 5:
                Butt.GetComponent<Image>().sprite = Sprite5;
                break;
            case 6:
                Butt.GetComponent<Image>().sprite = Sprite6;
                break;
            case 7:
                Butt.GetComponent<Image>().sprite = Sprite7;
                break;
            case 8:
                Butt.GetComponent<Image>().sprite = Sprite8;
                break;
        }
    }

    void TowerOnClick1()
    {
        GameObject go = GameObject.Find("pandaexpress");
    }
}