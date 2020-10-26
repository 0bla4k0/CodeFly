using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstItemSlot : MonoBehaviour, IDropHandler  // change script name
{
    public static bool SetInRightBoxFirstEye = false; // change var name

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && FirstDragDrop.FirstEye == true) // change
        {
            FirstDragDrop.MoveEye = false; // change
            if (FirstDragDrop.FirstEye)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                SetInRightBoxFirstEye = true; // change
            }
        }
    }

}