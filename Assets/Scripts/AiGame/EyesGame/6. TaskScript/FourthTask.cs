using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthTask : MonoBehaviour
{
    void Update()
    {
        if (EyesSpawn.FinishStudyAI)
        {
            GetComponent<Text>().color = new Color32(70, 140, 30, 255);
        }
        else
        {
            GetComponent<Text>().color = new Color32(195, 10, 10, 255);
        }
    }
}
