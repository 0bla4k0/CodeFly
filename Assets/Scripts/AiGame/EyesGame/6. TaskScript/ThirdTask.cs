﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdTask : MonoBehaviour
{
    void Update()
    {
        if (HealthyEye.TaskChekerConnect && FirstEye.TaskChekerConnect && SecondEye.TaskChekerConnect && ThirdEye.TaskChekerConnect)
        {
            GetComponent<Text>().color = new Color32(70, 140, 30, 255);
        }
        else
        {
            GetComponent<Text>().color = new Color32(195, 10, 10, 255);
        }
    }
}
