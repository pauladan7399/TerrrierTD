using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public static int StartLives = 20;
    void Start()
    {
        Lives = StartLives;
    }

    void update()
    {

    }
}

