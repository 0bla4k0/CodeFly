using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public static bool ClickArea = false;

    void OnMouseDown()
    {
        ClickArea = true;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) { ClickArea = true; }
        if (Input.GetMouseButtonDown(2)) { ClickArea = true; }
    }
}
