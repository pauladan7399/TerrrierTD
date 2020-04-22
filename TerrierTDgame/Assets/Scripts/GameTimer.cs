using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    public float seconds;
    public int minute;
    public Text TimerText;
    public Text minuteText;
    
    // Start is called before the first frame update
    void Start()
    {
        seconds = 0;
        minute = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= 59 && seconds <= 60)
        {
            seconds = 0;
            minute++;
        }
        
        
        if (seconds > 9)
        {
            TimerText.text = seconds.ToString("0");
        }
        else
        {
            TimerText.text = "0" + seconds.ToString("0");
        }

        if (minute > 9)
        {
            minuteText.text = minute.ToString("0");
        }
        else
        {
            minuteText.text = "0" + minute.ToString("0");
        }


        //TimerText.text = currentTime.ToString("0");
        //minuteText.text = minuteTime.ToString("0");
    }

    
}
