using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondTask : MonoBehaviour
{
    void Update()
    {
        if (DotLineMove.TaskCheckerConnectLine && FirstLineMove.TaskCheckerConnectLine && SecondCreateLine.TaskCheckerConnectLine && ThirdCreateLine.TaskCheckerConnectLine)
        {
            GetComponent<Text>().color = new Color32(70, 140, 30, 255);
        }
        else
        {
            GetComponent<Text>().color = new Color32(195, 10, 10, 255);
        }
    }
}
