using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public static ScoreControl instance;

    public float score, highScore;
    public Text scoreGame, scoreMenu, scoreRecord;

    void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("SaveScoreCarGame"))
        {
            highScore = PlayerPrefs.GetFloat("SaveScoreCarGame");
        }    
    }

    void Start()
    {
        score = 0;
        StartCoroutine(ScoreCounter());
    }

    void Update()
    {
        double scorePrint = score / 10;
        double highScorePrint = highScore / 10;
        string tmp = "Пройдено: " + scorePrint.ToString();
        string tmp1 = scorePrint.ToString();
        string tmp2 = highScorePrint.ToString();

        if (scorePrint - (int)scorePrint != 0)
        {
            tmp += " км";
        }
        else
        {
            tmp += ",0" + " км";
            tmp1 += ",0";
        }
        
        if (highScorePrint - (int)highScorePrint == 0)
        {
            tmp2 += ",0";
        }

        scoreGame.text = tmp;
        scoreMenu.text = tmp1;
        scoreRecord.text = tmp2;
    }

    IEnumerator ScoreCounter()
    {
        while (true)
        {
            Update();

            yield return new WaitForSeconds(1);
            instance.AddScore();
        }
    }

    public void AddScore()
    {
        score += 1;
        HighScore();
    }

    public void HighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("SaveScoreCarGame", highScore);
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScoreCarGame");
        highScore = 0;
    }
}
