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
    private bool showinstru = false;
    private bool changetext = false;

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
            instructions.text = ("");
        }


        //show instructions text
        if (Input.GetKeyDown(KeyCode.Z))
        {
            showinstru = true;
        }
        if (showinstru == true)
        {
            instructions.text = ("after gathering your group, stand by a waterbottle. Everyone should send the code at the same time.");
        }


        //change instructionstext
        if (Input.GetKeyDown(KeyCode.X))
        {
            changetext = true;
            
        }

        if (changetext == true)
        {
            instructions.text = ("Choose your favorite question, discuss, and send in your favorite response from your group.");
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