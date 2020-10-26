using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondConnectLine : MonoBehaviour  // change script name
{
    public static bool ConnectLineEnter = false;

    void Update()
    {
        if (SecondItemSlot.SetInRightBoxSecondEye) // change
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = new Color32(111, 111, 111, 255);
        }
    }

    void OnMouseEnter()
    {
        if (SecondCreateLine.MouseDragStart && SecondItemSlot.SetInRightBoxSecondEye) // change
        {
            ConnectLineEnter = true;
        }
    }

    void OnMouseExit()
    {
        if (SecondCreateLine.MouseDragStart && SecondItemSlot.SetInRightBoxSecondEye) // change
        {
            ConnectLineEnter = false;
        }
    }
}
