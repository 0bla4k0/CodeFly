using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyButton : MonoBehaviour
{
    public static bool Pressed = false;
    public void StartStudyLevel()
    {
        Pressed = true;
    }
}
