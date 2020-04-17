using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform eaglePrefab;
    public Transform beaverPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 2f; //time between waves, AFTER the wave has been cleared
    private float countdown = 2f;


    private int waveNumber = 20; //Starting on high wave for testing

    void Update () 
    {
        /*if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        } */

        if (GameObject.FindWithTag("Runner") == null){ 
            countdown -= Time.deltaTime; //counts down when there are no enemies 
            //eventually, this should trigger the tower selection phase, then count down when the player is doen choosing their towers
            //Wait for player to click done (opposed to putting the player on a timer)
        }
        if (countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
    }

    IEnumerator SpawnWave () {
        waveNumber++;
        for (int i=0; i<waveNumber; i++) {
            SpawnRunner();
            yield return new WaitForSeconds(0.2f);
        }
        
    }

    void SpawnRunner () {
        if (waveNumber % 2 == 0)
        {
            Instantiate(beaverPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(eaglePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
