using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   
    public static float LimitTime = 15f;
    [SerializeField]
    private TextMeshProUGUI text;
    void Start()
    {
        LimitTime = 15f;
    }
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text.text = "Time : " + Math.Round(LimitTime);
    }
}
