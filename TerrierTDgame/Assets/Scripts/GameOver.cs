﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private bool gameEnded = false;
    public float restartDelay = 5f;
    public SpriteRenderer sprite;

    // Update is called once per frame
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); //accessing SpriteRenderer
        sprite.color = new Color(1, 1, 1, 0);
    }
    
    void Update()
    {
        if (gameEnded == true)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
            gameEnded = true;
        }
    }

    void EndGame()
    {
        Debug.Log("You failed college!");
        sprite.color = new Color(1, 1, 1, 1);
        Invoke("Restart", restartDelay);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
