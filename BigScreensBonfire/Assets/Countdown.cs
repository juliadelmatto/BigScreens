using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class Countdown : MonoBehaviour
{
    public int timeLeft = 60; //Seconds Overall
    public Text countdown; //UI Text Object
    public Text instructions;

    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        if (timeLeft > 0)
        {
            countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
        }
        else if ((timeLeft>-1)&&(timeLeft<1))
        {
            countdown.text = ("Refresh page!!");
        }
        if (timeLeft <-1)
        {
            countdown.text = ("");
            instructions.text = ("find your group and then stand by a waterbottle.");
        }

    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}