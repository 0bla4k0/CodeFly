using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FisrstTask : MonoBehaviour
{
    void Update()
    {
        if (OneItemSlot.SetInRightBoxHealthyEye && FirstItemSlot.SetInRightBoxFirstEye && SecondItemSlot.SetInRightBoxSecondEye && ThirdItemSlot.SetInRightBoxThirdEye)
        {
            GetComponent<Text>().color = new Color32(70, 140, 30, 255);
        }
        else
        {
            GetComponent<Text>().color = new Color32(195, 10, 10, 255);
        }
    }
}
