using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdConnectLine : MonoBehaviour  // change script name
{
    public static bool ConnectLineEnter = false;

    void Update()
    {
        if (ThirdItemSlot.SetInRightBoxThirdEye) // change
        {
            GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            GetComponent<Image>().color = new Color32(111, 111, 111, 255);
        }
    }

    void OnMouseEnter()
    {
        if (ThirdCreateLine.MouseDragStart && ThirdItemSlot.SetInRightBoxThirdEye) // change
        {
            ConnectLineEnter = true;
        }
    }

    void OnMouseExit()
    {
        if (ThirdCreateLine.MouseDragStart && ThirdItemSlot.SetInRightBoxThirdEye) // change
        {
            ConnectLineEnter = false;
        }
    }
}
