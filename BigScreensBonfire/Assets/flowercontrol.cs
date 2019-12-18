using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowercontrol : MonoBehaviour
{

    public GameObject Main;
    public GameObject flower1;
   // public Animation f1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flower4;
    public GameObject flower5;
    public GameObject flower6;
    public GameObject flower7;
    public GameObject flower8;
    public GameObject flower9;
    public GameObject flower10;

    public Vector2 destination;
    public float speedoftransition;

    private bool flowersmove = false;
    private bool flower2move = false;
    private bool flower3move = false;
    private bool flower4move = false;


    // Start is called before the first frame update
    void Start()
    {
        flower1.SetActive(false);
        flower2.SetActive(false);
        flower3.SetActive(false); 
        flower4.SetActive(false);
        flower5.SetActive(false);
        flower6.SetActive(false);
        flower7.SetActive(false);
        flower8.SetActive(false);
        flower9.SetActive(false);
        flower10.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //QWER corresponds to each flower, makes it appear
        if((Main.GetComponent<Main>().groupone == true)){
            flower1.SetActive(true);
           
        }
        if ((Main.GetComponent<Main>().grouptwo == true)))
        {
            flower2.SetActive(true);
        }
        if((Main.GetComponent<Main>().groupthree == true))
        {
            flower3.SetActive(true);
        }
        if ((Main.GetComponent<Main>().groupfour == true))
        {
            flower4.SetActive(true);

        }
        if ((Main.GetComponent<Main>().groupfive == true))
        {
            flower5.SetActive(true);

        }
        if ((Main.GetComponent<Main>().groupsix == true))
        {
            flower6.SetActive(true);

        }
        if ((Main.GetComponent<Main>().groupseven == true))
        {
            flower7.SetActive(true);

        }
        if ((Main.GetComponent<Main>().groupeight == true))
        {
            flower8.SetActive(true);

        }
        if ((Main.GetComponent<Main>().groupnine == true))
        {
            flower9.SetActive(true);

        }
        if ((Main.GetComponent<Main>().groupten == true))
        {
            flower10.SetActive(true);

        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    //mainobject bool 1 == true
        //    flower1.SetActive(true);

        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{     
        //    flower2.SetActive(true);

        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    flower3.SetActive(true);

        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    flower4.SetActive(true);

        //}



        //ASDF corresponds to making each flower lerp to the center of the screen
        if (Input.GetKeyDown(KeyCode.A))
        {
            flowersmove = true;
        }

        if (flowersmove == true)
        {
            lerpFlower(destination,flower1);
            lerpFlower(destination, flower2);
            lerpFlower(destination, flower3);
            lerpFlower(destination, flower4);
            lerpFlower(destination, flower5);
            lerpFlower(destination, flower6);
            lerpFlower(destination, flower7);
            lerpFlower(destination, flower8);
            lerpFlower(destination, flower9);
            lerpFlower(destination, flower10);
        }
        ////
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    flower2move = true;
        //}

        //if (flower2move == true)
        //{
        //    lerpFlower(destination, flower2);
        //}
        //////
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    flower3move = true;
        //}

        //if (flower3move == true)
        //{
        //    lerpFlower(destination, flower3);
        //}
        /////
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    flower4move = true;
        //}

        //if (flower4move == true)
        //{
        //    lerpFlower(destination, flower4);
        //}
    }

   public void lerpFlower(Vector2 dest, GameObject flower)
    {
        flower.transform.position = Vector3.Lerp(flower.transform.position,
            new Vector2(dest.x, dest.y),
            speedoftransition);

        if (Vector2.Distance(flower.transform.position, dest) < 0.05)
        {

            flower.transform.position = new Vector3(dest.x, dest.y, -10);
         
        }
    }
}
