using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStudyButton : MonoBehaviour
{
    public static bool Pressed = false;
    public void FinishStudy()
    {
        Pressed = true;
    }
}
