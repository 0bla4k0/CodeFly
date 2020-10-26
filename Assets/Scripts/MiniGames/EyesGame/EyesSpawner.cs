using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesSpawner : MonoBehaviour
{
    public static EyesSpawner instance;

    public List<GameObject> EyesList;
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int score, highScore;
    public Text scoreGame, scoreMenu, scoreRecord;

    public Slider mySlider;
    float TimeLevel;

    bool RightAnswer = false;
    bool WrongAnswer = true;
    bool Restart = false;

    public static int tmp = 0;
    public GameObject RestartMenu;
    public int temp = 0;
    float randomX, randomY;
    public int EyeIndex;

    void Awake()
    {
        // Open HighScore
        instance = this;
        if (PlayerPrefs.HasKey("SaveScoreEyesGame"))
        {
            highScore = PlayerPrefs.GetInt("SaveScoreEyesGame");
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        RestartMenu.SetActive(false);
        score = 0;
        StartCoroutine(Spawner());
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (numOfHearts > i)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health == 0)
        {
            Time.timeScale = 0f;
            RestartMenu.SetActive(true);
        }

        // Print score and MathProblem
        scoreGame.text = "Счет: " + score.ToString();
        scoreMenu.text = score.ToString();
        scoreRecord.text = highScore.ToString();

        // Add score for right answer or minus heart
        if (RightAnswer)
        {
            instance.AddScore();
            Restart = true;
        }
        else if (WrongAnswer == false)
        {
            Restart = true;
            health--;
        }

        // Restart level        
        if (Restart)
        {
            RightAnswer = false;
            WrongAnswer = true;
            Restart = false;
            ClickScript.ClickArea = false;
            TimeLevel = 1;
            StartCoroutine(Spawner());
        }

        Debug.Log(ClickScript.ClickArea);
    }

    void FixedUpdate()
    {
        if (tmp == 0)
        {
            Time.timeScale = 0f;
            RestartMenu.SetActive(true);
            tmp++;
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
        randomX = Random.Range(100.0f, 700.0f); randomY = Random.Range(100.0f, 275.0f);
        GameObject eye = Instantiate(EyesList[EyeIndex], new Vector2(Random.Range(100.0f, 700.0f), Random.Range(100.0f, 275.0f)), Quaternion.identity);
        while (true)
        {
            yield return new WaitForSeconds(0);

            if (Input.GetMouseButtonDown(0) && EyeIndex == 0 && ClickScript.ClickArea) { RightAnswer = true; break; }
            else if (Input.GetMouseButtonDown(0) && EyeIndex != 0 && ClickScript.ClickArea) { WrongAnswer = false; break; }

            if (Input.GetMouseButtonDown(1) && (EyeIndex == 1 || EyeIndex == 2) && ClickScript.ClickArea) { RightAnswer = true; break; }
            else if (Input.GetMouseButtonDown(1) && (EyeIndex == 0 || EyeIndex == 3) && ClickScript.ClickArea) { WrongAnswer = false; break; }

            if (Input.GetMouseButtonDown(2) && EyeIndex == 3 && ClickScript.ClickArea) { RightAnswer = true; break; }
            else if (Input.GetMouseButtonDown(2) && EyeIndex != 3 && ClickScript.ClickArea) { WrongAnswer = false; break; }

            // Level timer
            mySlider.value = TimeLevel;
            TimeLevel -= 0.004f;

            if (TimeLevel <= 0)
            {
                WrongAnswer = false;
                break;
            }
        }
        Destroy(eye);
    }

    public void AddScore()
    {
        score += 1;
        HighScore();
    }

    // Save new HighScore
    public void HighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("SaveScoreEyesGame", highScore);
        }
    }

    // Reset logs
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScoreEyesGame");
        highScore = 0;
    }
}
