using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float timer = 0;

    public GameObject block;
    public GameObject pillar;
    public GameObject log;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += SpeedManager.totalSpeed;
        if (timer >= 12) {
            timer = 0;
            int ob = (Random.Range(0, 6));

            if(ob < 2){
                Instantiate(block, new Vector3((Random.Range(-1, 2) * 4), 0.6f, 200), transform.rotation);
            }

            if (ob == 2)
            {
                Instantiate(pillar, new Vector3((Random.Range(-1, 2) * 4), 2, 200), transform.rotation);
            }

            if (ob == 3)
            {
                if (Random.Range(0, 4) == 0)
                {
                    Instantiate(log, new Vector3(0, 5f, 200), transform.rotation);
                }
                else
                {
                    Instantiate(log, new Vector3(0, 0.5f, 200), transform.rotation);
                }
            }
        }
    }
}
