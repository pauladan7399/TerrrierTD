using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform eaglePrefab;
    public Transform beaverPrefab;
    public Transform lepPrefab;
    public Transform bulldogPrefab;
    public Transform lionPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f; //time between waves, AFTER the wave has been cleared
    private float countdown = 5f;
    public GameObject SelectionUI;
    public Text waveText;

    //private float selectionTimer = 10f;
    //[SerializeField] Text SelectionTimerText2;
    public static int spawnchecker = 0;

    private int waveNumber = 20; //Starting on high wave for testing

    void Update () 
    {
        /*if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        } */

       // if (GameObject.FindWithTag("Runner") != null)
       // {
       //     SelectionUI.SetActive(false);
       // }
        if (GameObject.FindWithTag("Runner") == null && SelectionUI.activeSelf == false){ 
            countdown -= Time.deltaTime; //counts down when there are no enemies 
            //eventually, this should trigger the tower selection phase, then count down when the player is doen choosing their towers
            //Wait for player to click done (opposed to putting the player on a timer)i
            
           
        }
        if (countdown <= 0f){
            if (CheckTab())
                SelectionUI.SetActive(false);
            else
                SelectionUI.SetActive(true);

            Debug.Log("Activating Selection ");
            Debug.Log("stupid code");
            //selectionTimer -= Time.deltaTime;
           // SelectionTimerText2.text = Mathf.Round(selectionTimer).ToString();
          
            if (CheckTab())
            {
                Debug.Log("Spawning runners ");
                StartCoroutine(SpawnWave());
                spawnchecker = 0;
            }
            countdown = timeBetweenWaves;
        }
    }

    IEnumerator SpawnWave () {
        waveNumber++;
        waveText.text = "Wave " + waveNumber.ToString();
        for (int i=0; i<waveNumber; i++) {
            SpawnRunner();
            yield return new WaitForSeconds(0.2f);
        }
        
    }

    void SpawnRunner () {
        if (waveNumber % 5 == 0)
        {
            Instantiate(beaverPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (waveNumber % 5 == 1)
        {
            Instantiate(eaglePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (waveNumber % 5 == 2)
        {
            Instantiate(lepPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (waveNumber % 5 == 3)
        {
            Instantiate(lionPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (waveNumber % 5 == 4)
        {
            Instantiate(bulldogPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    bool CheckTab() //This is to do bool and check when to spawn
    {
        if (spawnchecker == 0) 
            return false;
        else 
            return true;

    }
}
