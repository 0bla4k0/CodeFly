using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OneItemSlot : MonoBehaviour, IDropHandler  // change script name
{
    public static bool SetInRightBoxHealthyEye = false; // change var name

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && DragDrop.HealthyEye == true) // change
        {
            DragDrop.MoveEye = false; // change
            if (DragDrop.HealthyEye) // change
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                SetInRightBoxHealthyEye = true; // change
            }
        }
    }

}