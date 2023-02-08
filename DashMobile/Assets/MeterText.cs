using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterText : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI mText;
    private float score = 0;
    void Start()
    {
        mText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score += SpeedManager.totalSpeed;
        mText.text = Mathf.Round(score) + "m";
    }
}
