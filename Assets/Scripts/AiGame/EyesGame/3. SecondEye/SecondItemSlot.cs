using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SecondItemSlot : MonoBehaviour, IDropHandler  // change script name
{
    public static bool SetInRightBoxSecondEye = false; // change var name

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && SecondDragDrop.SecondEye == true) // change
        {
            SecondDragDrop.MoveEye = false; // change
            if (SecondDragDrop.SecondEye)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                SetInRightBoxSecondEye = true; // change
            }
        }
    }

}