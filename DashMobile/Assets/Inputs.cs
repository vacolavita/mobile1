using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public static bool inputJump = false;
    public static int inputHorizontal = 0;
    public static bool inputDash = false;
    public static bool inputFall = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputJump = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputFall = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputHorizontal = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputHorizontal = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputDash = true;
        }
    }
}
