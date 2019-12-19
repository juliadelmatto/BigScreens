using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeCube : MonoBehaviour
{

    private Animator cube;
    // Start is called before the first frame update
    void Start()
    {
        cube = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            cube.SetTrigger("FadeCube");
        }
    }
}
