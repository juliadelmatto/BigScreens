using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowercontrol : MonoBehaviour
{
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flower4;

    public Vector2 destination;
    public float speedoftransition;

    private bool flower1move = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        //QWER corresponds to each flower, makes it appear
        if (Input.GetKeyDown(KeyCode.Q))
        {
            flower1.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {     
            flower2.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            flower3.SetActive(true);
           
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            flower4.SetActive(true);
            
        }



        //ASDF corresponds to making each flower lerp to the center of the screen
        if (Input.GetKeyDown(KeyCode.A))
        {
            flower1move = true;
        }

        if (flower1move == true)
        {
            lerpFlower(destination,flower1);
        }
        ////
        if (Input.GetKeyDown(KeyCode.S))
        {
            flower2move = true;
        }

        if (flower2move == true)
        {
            lerpFlower(destination, flower2);
        }
        ////
        if (Input.GetKeyDown(KeyCode.D))
        {
            flower3move = true;
        }

        if (flower3move == true)
        {
            lerpFlower(destination, flower3);
        }
        ///
        if (Input.GetKeyDown(KeyCode.F))
        {
            flower4move = true;
        }

        if (flower4move == true)
        {
            lerpFlower(destination, flower4);
        }
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
