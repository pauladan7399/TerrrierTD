using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
   public Text livesText;
   public Transform Test;

   void Update ()
   {
       //livesText.text = PlayerStats.Lives.ToString(); 
       if (PlayerStats.Lives >= PlayerStats.StartLives*(0.8))
       {
           livesText.text = "A";

       }
       else if (PlayerStats.Lives >= PlayerStats.StartLives*(0.6))
       {
           livesText.text = "B";
       }
       else if (PlayerStats.Lives >= PlayerStats.StartLives*(0.4))
       {
           livesText.text = "C";
       }
       else if (PlayerStats.Lives >= PlayerStats.StartLives*(0.2))
       {
           livesText.text = "D";
       }
       else if (PlayerStats.Lives >= -1000)
       {
           livesText.text = "FAILING!";
       }
   }
}
