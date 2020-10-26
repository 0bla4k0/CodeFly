using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButtonPressed : MonoBehaviour
{
    public static bool Pressed = false;
    public void CheckButton()
    {
        Pressed = true;
    }
}
