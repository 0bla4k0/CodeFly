using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EyesSpawn : MonoBehaviour
{
    public List<GameObject> EyesList;
    public bool RightAnswer = false;
    public bool WrongAnswer = false;
    public bool Restart = false;
    public int temp = 0;
    public int ZeroTempPrint = 0;
    public string Zero;
    public int EyeIndex;
    public Text WNumbers, Iterations;
    public int w1, w2, w3, w4;
    public int a = 100;
    public int b = 1550;
    public int iterations;
    public GameObject FinishStudyMenu;
    public static bool FinishStudyAI = false;
    public static int WrongAnswersForChecking = 0;

    void Start()
    {
        EyeIndex = Random.Range(0, 4);
        temp = EyeIndex;
        iterations = 16;
        FinishStudyMenu.SetActive(false);
    }

    void Update()
    {
        print(WrongAnswersForChecking);
        if (iterations == 0)
        {
            FinishStudyMenu.SetActive(true);
            FinishStudyAI = true;
        }

        if (FinishStudyButton.Pressed)
        {
            StudyButton.Pressed = false;
            FinishStudyMenu.SetActive(false);
            FinishStudyButton.Pressed = false;
            ZeroTempPrint = 0;
        }

        if (RestudyButton.Pressed)
        {
            RestudyButton.Pressed = false;
            FinishStudyMenu.SetActive(false);
            Restart = true;
            w1 = 0; w2 = 0; w3 = 0; w4 = 0;
            ZeroTempPrint = 0;
            WrongAnswersForChecking = 0;
            CreateWay.StartFEye = false; 
            FCreateWay.StartSEye = false; 
            SCreateWay.StartTEye = false; 
            TCreateWay.StartGGEye = false;
            CheckButtonPressed.Pressed = false;
            Start();
        }

        if (RightAnswer)
        {
            Restart = true;
        }
        else if (WrongAnswer == false)
        {
            Restart = true;
            WrongAnswersForChecking += 1;
        }

        if (Restart)
        {
            if (ZeroTempPrint == 0)
            {
                Zero = "0000  ";
                ZeroTempPrint += 1;
            }
            else if( ZeroTempPrint == 1)
            {
                Zero = "00  ";
                ZeroTempPrint += 1;
            }
            else
            {
                Zero = "0  ";
            }
            iterations -= 1;
            WNumbers.text = "w1 = " + "0." + w1.ToString() + Zero + "w2 = " + "0." + w2.ToString() + Zero + "w3 = " + "0." + w3.ToString() + Zero + "w4 = " + "0." + w4.ToString() + Zero;
            Iterations.text = "Повторений осталось: " + iterations.ToString();
            RightAnswer = false;
            WrongAnswer = true;
            Restart = false;
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        WrongAnswer = true;
        while (temp == EyeIndex)
        {
            EyeIndex = Random.Range(0, 4);
        }
        temp = EyeIndex;
        if (iterations > 0)
        {
            GameObject eye = Instantiate(EyesList[EyeIndex], new Vector2(631f, 256f), Quaternion.identity);
            while (true)
            {
                yield return new WaitForSeconds(0);

                if (Input.GetKeyDown(KeyCode.A) && EyeIndex == 0) { RightAnswer = true; w1 += Random.Range(a + 50, b + 200); w2 += Random.Range(a, b); w3 += Random.Range(a, b); w4 += Random.Range(a, b); break; }
                else if (Input.GetKeyDown(KeyCode.A) && EyeIndex != 0) { WrongAnswer = false; w2 += Random.Range(a + 50, b); w1 += Random.Range(a, b); w3 += Random.Range(a, b); w4 += Random.Range(a, b); break; }

                if (Input.GetKeyDown(KeyCode.W) && EyeIndex == 1) { RightAnswer = true; w2 += Random.Range(a, b + 200); w1 += Random.Range(a, b); w3 += Random.Range(a, b); w4 += Random.Range(a, b); break; }
                else if (Input.GetKeyDown(KeyCode.W) && EyeIndex != 1) { WrongAnswer = false; w2 += Random.Range(a + 50, b); w1 += Random.Range(a, b); w3 += Random.Range(a, b); w4 += Random.Range(a, b); break; }

                if (Input.GetKeyDown(KeyCode.D) && EyeIndex == 2) { RightAnswer = true; w3 += Random.Range(a, b + 200); w2 += Random.Range(a, b); w1 += Random.Range(a, b); w4 += Random.Range(a, b); break; }
                else if (Input.GetKeyDown(KeyCode.D) && EyeIndex != 2) { WrongAnswer = false; w2 += Random.Range(a + 50, b); w1 += Random.Range(a, b); w3 += Random.Range(a, b); w4 += Random.Range(a, b); break; }

                if (Input.GetKeyDown(KeyCode.S) && EyeIndex == 3) { RightAnswer = true; w4 += Random.Range(a, b + 200); w2 += Random.Range(a, b); w3 += Random.Range(a, b); w1 += Random.Range(a, b); break; }
                else if (Input.GetKeyDown(KeyCode.S) && EyeIndex != 3) { WrongAnswer = false; w2 += Random.Range(a + 50, b); w1 += Random.Range(a, b); w3 += Random.Range(a, b); w4 += Random.Range(a, b); break; }
            }
            Destroy(eye);
        }
    }
}
