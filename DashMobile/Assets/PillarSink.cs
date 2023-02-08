using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -3.7f && transform.position.x == 0) {
                Destroy(gameObject);
        }
    }
}
