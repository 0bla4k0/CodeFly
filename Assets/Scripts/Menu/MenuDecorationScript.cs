using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDecorationScript : MonoBehaviour
{
    public Text DecorationText;
    int Temperature, FanSpeed;

    void Start()
    {
        StartCoroutine(TextRandom());
    }

    IEnumerator TextRandom()
    {
        while (true)
        {
            Temperature = Random.Range(30, 35);
            FanSpeed = Random.Range(830, 850);
            DecorationText.text = "CPU Temperature Control: " + Temperature.ToString() + " (C)" + "\n" + "Q-Fan Control: " + FanSpeed.ToString() + " (RPM)";
            yield return new WaitForSeconds(1);
            Temperature = Random.Range(30, 35);
            FanSpeed = Random.Range(830, 850);
            DecorationText.text = "CPU Temperature Control: " + Temperature.ToString() + " (C)" + "\n" + "Q-Fan Control: " + FanSpeed.ToString() + " (RPM)";
        }
    }

}
