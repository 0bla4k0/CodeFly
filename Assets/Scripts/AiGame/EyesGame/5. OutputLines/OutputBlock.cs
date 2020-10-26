using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputBlock : MonoBehaviour
{
    public static bool HConnectLineEnter = false;
    public static bool FConnectLineEnter = false;
    public static bool SConnectLineEnter = false;
    public static bool TConnectLineEnter = false;

    void Update()
    {
        if (OneItemSlot.SetInRightBoxHealthyEye || FirstItemSlot.SetInRightBoxFirstEye || SecondItemSlot.SetInRightBoxSecondEye || ThirdItemSlot.SetInRightBoxThirdEye) // change
        {
            GetComponent<Image>().color = Color.cyan;
        }
        else
        {
            GetComponent<Image>().color = new Color32(111, 111, 111, 255);
        }
    }

    void OnMouseEnter()
    {
        if (HealthyEye.MouseDragStart && OneItemSlot.SetInRightBoxHealthyEye) // change
        {
            HConnectLineEnter = true;
        }
        else if (FirstEye.MouseDragStart && FirstItemSlot.SetInRightBoxFirstEye)
        {
            FConnectLineEnter = true;
        }
        else if (SecondEye.MouseDragStart && SecondItemSlot.SetInRightBoxSecondEye)
        {
            SConnectLineEnter = true;
        }
        else if (ThirdEye.MouseDragStart && ThirdItemSlot.SetInRightBoxThirdEye)
        {
            TConnectLineEnter = true;
        }
    }

    void OnMouseExit()
    {
        if (HealthyEye.MouseDragStart) // change
        {
            HConnectLineEnter = false;
        }
        else if (FirstEye.MouseDragStart)
        {
            FConnectLineEnter = false;
        }
        else if (SecondEye.MouseDragStart)
        {
            SConnectLineEnter = false;
        }
        else if (ThirdEye.MouseDragStart)
        {
            TConnectLineEnter = false;
        }
    }
}
