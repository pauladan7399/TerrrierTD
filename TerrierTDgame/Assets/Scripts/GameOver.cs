using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool gameEnded = false;

    // Update is called once per frame
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
    }
}
