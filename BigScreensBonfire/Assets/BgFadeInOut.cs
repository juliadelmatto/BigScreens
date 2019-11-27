using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BgFadeInOut : MonoBehaviour
{
    public Image bgimage1;
    public Image bgimage2;
    public Image bgimage3;

    private bool fade1 = false;
    private bool fade2 = false;
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
            c.a -= 0.01f;

            bgimage1.color = c;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            fade1 = true;
        }


        if (fade2)
        {
            Color c2 = bgimage2.color;
            c2.a -= 0.01f;

            bgimage2.color = c2;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            fade2 = true;
        }
    }
}
    