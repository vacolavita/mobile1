using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static int speed = 12;
    public static float boost = 1;
    public float timer = 0;
    public static bool gameOver = false;
    public static float totalSpeed => speed * boost * Time.deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5) {
            if (!gameOver)
            {
                speed++;
                timer = 0;
            }
        }
    }
}
