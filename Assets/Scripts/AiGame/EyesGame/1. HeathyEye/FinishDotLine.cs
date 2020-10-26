using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishDotLine : MonoBehaviour  // change script name
{
    public static bool ConnectLineEnter = false;

    void Update()
    {
        if (OneItemSlot.SetInRightBoxHealthyEye) // change
        {
            GetComponent<Image>().color = Color.blue;
        }
        else
        {
            GetComponent<Image>().color = new Color32(111, 111, 111, 255);
        }
    }

    void OnMouseEnter()
    {
        if (DotLineMove.MouseDragStart && OneItemSlot.SetInRightBoxHealthyEye) // change
        {
            ConnectLineEnter = true;
        }
    }

    void OnMouseExit()
    {
        if (DotLineMove.MouseDragStart && OneItemSlot.SetInRightBoxHealthyEye) // change
        {
            ConnectLineEnter = false;
        }
    }
}
