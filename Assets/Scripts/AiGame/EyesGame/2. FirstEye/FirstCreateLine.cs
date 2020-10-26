using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstCreateLine : MonoBehaviour  // change script name
{
    public static bool ConnectLineEnter = false;

    void Update()
    {
        if (FirstItemSlot.SetInRightBoxFirstEye) // change
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = new Color32(111, 111, 111, 255);
        }
    }

    void OnMouseEnter()
    {
        if (FirstLineMove.MouseDragStart && FirstItemSlot.SetInRightBoxFirstEye) // change
        {
            ConnectLineEnter = true;
        }
    }

    void OnMouseExit()
    {
        if (FirstLineMove.MouseDragStart && FirstItemSlot.SetInRightBoxFirstEye) // change
        {
            ConnectLineEnter = false;
        }
    }
}
