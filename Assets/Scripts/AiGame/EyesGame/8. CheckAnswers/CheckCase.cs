using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCase : MonoBehaviour
{
    public Text testCase1;
    public Text testCase2;
    public Text testCase3;
    public Text testCase4;

    void Update()
    {
        if(EyesSpawn.FinishStudyAI)
        {
            if (CheckButtonPressed.Pressed)
            {
                if (EyesSpawn.WrongAnswersForChecking >= 0 && EyesSpawn.WrongAnswersForChecking <= 3)
                {
                    if (CreateWay.StartFEye)
                    {
                        testCase1.text = "Test case #1 - ok";
                        testCase1.color = new Color32(70, 140, 30, 255);
                    }
                    if (FCreateWay.StartSEye)
                    {
                        testCase2.text = "Test case #2 - ok";
                        testCase2.color = new Color32(70, 140, 30, 255);
                    }
                    if (SCreateWay.StartTEye)
                    {
                        testCase3.text = "Test case #3 - ok";
                        testCase3.color = new Color32(70, 140, 30, 255);
                    }
                    if (TCreateWay.StartGGEye)
                    {
                        testCase4.text = "Test case #4 - ok";
                        testCase4.color = new Color32(70, 140, 30, 255);
                    }
                }
                else if (EyesSpawn.WrongAnswersForChecking >= 4 && EyesSpawn.WrongAnswersForChecking <= 8)
                {
                    if (CreateWay.StartFEye)
                    {
                        testCase1.text = "Test case #1 - ok";
                        testCase1.color = new Color32(70, 140, 30, 255);
                    }
                    if (FCreateWay.StartSEye)
                    {
                        testCase2.text = "Test case #2 - wa";
                        testCase2.color = new Color32(195, 10, 10, 255);
                    }
                    if (SCreateWay.StartTEye)
                    {
                        testCase3.text = "Test case #3 - ok";
                        testCase3.color = new Color32(70, 140, 30, 255);
                    }
                    if (TCreateWay.StartGGEye)
                    {
                        testCase4.text = "Test case #4 - wa";
                        testCase4.color = new Color32(195, 10, 10, 255);
                    }
                }
                else if (EyesSpawn.WrongAnswersForChecking >= 9 && EyesSpawn.WrongAnswersForChecking <= 12)
                {
                    if (CreateWay.StartFEye)
                    {
                        testCase1.text = "Test case #1 - wa";
                        testCase1.color = new Color32(195, 10, 10, 255);
                    }
                    if (FCreateWay.StartSEye)
                    {
                        testCase2.text = "Test case #2 - wa";
                        testCase2.color = new Color32(195, 10, 10, 255);
                    }
                    if (SCreateWay.StartTEye)
                    {
                        testCase3.text = "Test case #3 - ok";
                        testCase3.color = new Color32(70, 140, 30, 255);
                    }
                    if (TCreateWay.StartGGEye)
                    {
                        testCase4.text = "Test case #4 - wa";
                        testCase4.color = new Color32(195, 10, 10, 255);
                    }
                }
                else
                {
                    if (CreateWay.StartFEye)
                    {
                        testCase1.text = "Test case #1 - wa";
                        testCase1.color = new Color32(195, 10, 10, 255);
                    }
                    if (FCreateWay.StartSEye)
                    {
                        testCase2.text = "Test case #2 - wa";
                        testCase2.color = new Color32(195, 10, 10, 255);
                    }
                    if (SCreateWay.StartTEye)
                    {
                        testCase3.text = "Test case #3 - wa";
                        testCase3.color = new Color32(195, 10, 10, 255);
                    }
                    if (TCreateWay.StartGGEye)
                    {
                        testCase4.text = "Test case #4 - wa";
                        testCase4.color = new Color32(195, 10, 10, 255);
                    }
                }
            }
            else
            {
                testCase1.text = "";
                testCase2.text = "";
                testCase3.text = "";
                testCase4.text = "";
            }
        }
        else
        {
            testCase1.text = "";
            testCase2.text = "";
            testCase3.text = "";
            testCase4.text = "";
        }
        
    }
}
