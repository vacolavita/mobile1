using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObMove : MonoBehaviour
{
    private Rigidbody obRb;
    // Start is called before the first frame update
    void Start()
    {
        obRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -SpeedManager.totalSpeed));
        if (transform.position.z < -20) {
            Destroy(gameObject);
        }


    }
}
