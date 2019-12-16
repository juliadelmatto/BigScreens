using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BgFadeInOut : MonoBehaviour
{
    public Image bgimage1;
    public Image bgimage2;
    public Image bgimage3;
    public Image main;
    public Image black;

    private bool fade1 = false;
    private bool fade2 = false;
    private bool fademain = false;
    private bool end = false;

    void Start()
    {
        bgimage1 = GetComponent<Image>();
        bgimage1.color = Color.white; //or whatever color


        //Color c = image.color;
        //c.a = 0.5f;
        //image.color = c;
    }
    private void Update()
    {
        if (fade1)
        {
            Color c = bgimage1.color;
            c.a -= 0.001f;

            bgimage1.color = c;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            fade1 = true;
        }


        if (fade2)
        {
            Color c2 = bgimage2.color;
            c2.a -= 0.001f;

            bgimage2.color = c2;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            fade2 = true;
        }



        if (fademain)
        {
            Color c3 = main.color;
            c3.a -= 0.001f;

            main.color = c3;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            fademain = true;
        }


        if (end)
        {
            Color c4 = black.color;
            c4.a += 0.001f;

            black.color = c4;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            end = true;
        }
    }
}
    