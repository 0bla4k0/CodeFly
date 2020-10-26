using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStudyUI : MonoBehaviour
{
    public GameObject StudyUI;

    void Start()
    {
        StudyUI.SetActive(false);
    }


    void Update()
    {
        if (StudyButton.Pressed)
        {
            StudyUI.SetActive(true);
        }
        else
        {
            StudyUI.SetActive(false);
        }
    }
}
