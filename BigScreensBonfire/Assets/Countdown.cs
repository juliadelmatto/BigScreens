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

    public Text title;
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
            countdown.text = ("Type to find who you are talking to!");
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
            title.text = "";
            instructions.text = ("After gathering your group, stand by a flower. Take turns answering questions and adding petals");
            instructions2.text = ("After gathering your group, stand by a flower. Take turns answering questions and adding petals");
        }


        //change instructionstext
        if (Input.GetKeyDown(KeyCode.X))
        {
            changetext = true;
            
        }

        if (changetext == true)
        {
            title.text = ("The End");
            //instructions.text = ("Discuss the questions, and send your own favorite answers from the group to make your flower grow stronger");
            //instructions2.text = ("Discuss the questions, and send your own favorite answers from the group to make your flower grow stronger");
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