using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimerCountdown : MonoBehaviour
{
    TextMeshProUGUI timerText;
    public int secondsLeft = 60;
    public int minutesLeft = 3;
    public bool takingAway = false;
    bool timeOut = false;

    void Start()
    {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
        timerText.text = "0" + minutesLeft.ToString() + ":" + secondsLeft.ToString();
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        else if (takingAway == false && secondsLeft == 0 && minutesLeft > 0)
        {
            secondsLeft = 60;
            minutesLeft -= 1;
            StartCoroutine(TimerTake());
        }
        if(minutesLeft == 0 && secondsLeft == 0)
        {
            timeOut = true;
        }
        
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        --secondsLeft;
        if(secondsLeft < 10)
        {
            timerText.text = "0" + minutesLeft.ToString() + ":0" + secondsLeft.ToString();
        }
        else
        {
            timerText.text = "0" + minutesLeft.ToString() + ":" + secondsLeft.ToString();
        }
        
        takingAway = false;
    }

    public bool TimeOut()
    {
        return timeOut;
    }
}
