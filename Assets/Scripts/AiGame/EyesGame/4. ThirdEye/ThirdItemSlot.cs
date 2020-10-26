using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdItemSlot : MonoBehaviour, IDropHandler  // change script name
{
    public static bool SetInRightBoxThirdEye = false; // change var name

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && ThirdDragDrop.ThirdEye == true) // change
        {
            ThirdDragDrop.MoveEye = false; // change
            if (ThirdDragDrop.ThirdEye)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                SetInRightBoxThirdEye = true; // change
            }
        }
    }

}