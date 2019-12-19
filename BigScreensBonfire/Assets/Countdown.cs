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
    public Text instructions2;
    private bool showinstru = false;
    private bool changetext = false;
    private bool starttimer=false;
    private bool nomoretext = false;
    public GameObject fire;
    public Text ournames;
    public Text title;
    public int timeTextLast = -6;

    void Start()
    {
        countdown.text = ("Wait for the countdown to enter the chatroom on your phone");

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            fire.SetActive(true);
        }

        if (starttimer == true)
        {
            
            if (timeLeft > 0)
            {
                countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
            }
            else if ((timeLeft > -1) && (timeLeft < 1))
            {
                countdown.text = ("Type on your phone to find your group");
            }
            if (timeLeft < timeTextLast)
            {
                countdown.text = ("");
                instructions.text = ("");
                instructions2.text = ("");
                title.text = ("");
                ournames.text =  ("");
            }
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            starttimer = true;
            countdown.text = ("5");
            StartCoroutine("LoseTime");
            Time.timeScale = 1; //Just making sure that the timeScale is right

        }
            //show instructions text
            if (Input.GetKeyDown(KeyCode.Z))
        {
            showinstru = true;
        }
        if (showinstru == true)
        {
            title.text = "";
            //instructions.text = ("After gathering your group, sit around a flower.");
            //instructions2.text = ("After gathering your group, sit around a flower.");
            countdown.text = ("After gathering your group, sit around a flower.");
          //  instructions2.text = ("After gathering your group, sit around a flower.");
        }


        //change instructionstext
        if (Input.GetKeyDown(KeyCode.X))
        {
            changetext = true;
            
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            nomoretext = true;
            //instructions.text = ("");
            //instructions2.text = ("");
            //countdown.text = ("");

        }
        if (nomoretext)
        {
            instructions.text = ("");
            instructions2.text = ("");
            countdown.text = ("");
        }

        if (changetext == true)
        {
            title.text = ("The End");
            //instructions.text = ("Feel free to take a flower petal but please leave the wooden pieces");
            //instructions2.text = ("Feel free to take a flower petal but please leave the wooden pieces");
            countdown.text = ("Feel free to take a flower petal but please leave the wooden pieces");
            fire.SetActive(false);
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