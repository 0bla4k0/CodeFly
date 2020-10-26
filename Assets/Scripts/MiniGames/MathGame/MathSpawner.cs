using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathSpawner : MonoBehaviour
{
    public static MathSpawner instance;

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int score, highScore;
    public Text scoreGame, scoreMenu, scoreRecord;
    
    public int number1, number2, answer;
    public Text num;
    string PrintMathProblem;

    public Slider mySlider;
    float TimeLevel;
    
    bool RightAnswer = false;
    bool WrongAnswer = true;
    bool Restart = false;
   
    public static int tmp = 0;
    public GameObject RestartMenu;
    int colorIndex = 0;
    int tempColorIndex = 0;

    List<Color> colorList = new List<Color>()
    {
         Color.red,
         Color.green,
         Color.yellow,
         Color.magenta,
         Color.blue,
         Color.gray,
         Color.cyan,
         Color.magenta
    };


    void Awake()
    {
        // Open HighScore
        instance = this;
        if (PlayerPrefs.HasKey("SaveScoreMathGame"))
        {
            highScore = PlayerPrefs.GetInt("SaveScoreMathGame");
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        RestartMenu.SetActive(false);
        score = 0;
        number1 = Random.Range(0, 9);
        number2 = Random.Range(0, 9);
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
        num.color = colorList[colorIndex];
        num.text = PrintMathProblem;

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
            TimeLevel = 1;
            number1 = Random.Range(0, 9);
            number2 = Random.Range(0, 9);
            while (colorIndex == tempColorIndex)
            {
                colorIndex = Random.Range(0, 8);
            }
            tempColorIndex = colorIndex;
            StartCoroutine(Spawner());
        }
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
        while (true)
        {
            // Spawn MathProblem
            yield return new WaitForSeconds(0);

            if (number1 * number2 >= 0 && number1 * number2 <= 9)
            {
                PrintMathProblem = number1.ToString() + " * " + number2.ToString();
                answer = number1 * number2;
            }

            else if (number1 / number2 >= 1 && number1 / number2 <= 9 && number1 % number2 == 0)
            {
                PrintMathProblem = number1.ToString() + " / " + number2.ToString();
                answer = number1 / number2;
            }

            else if (number2 / number1 >= 1 && number2 / number1 <= 9 && number2 % number1 == 0)
            {
                PrintMathProblem = number2.ToString() + " / " + number1.ToString();
                answer = number2 / number1;
            }

            else if (number1 + number2 >= 0 && number1 + number2 <= 9)
            {
                PrintMathProblem = number1.ToString() + " + " + number2.ToString();
                answer = number1 + number2;
            }

            else if (number1 - number2 >= 0 && number1 - number2 <= 9)
            {
                PrintMathProblem = number1.ToString() + " - " + number2.ToString();
                answer = number1 - number2;
            }

            else if (number2 - number1 >= 0 && number2 - number1 <= 9)
            {
                PrintMathProblem = number2.ToString() + " - " + number1.ToString();
                answer = number2 - number1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha0) && answer == 0) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha0) && answer != 0) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha1) && answer == 1) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && answer != 1) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha2) && answer == 2) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && answer != 2) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha3) && answer == 3) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && answer != 3) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha4) && answer == 4) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && answer != 4) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha5) && answer == 5) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && answer != 5) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha6) && answer == 6) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha6) && answer != 6) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha7) && answer == 7) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha7) && answer != 7) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha8) && answer == 8) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha8) && answer != 8) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.Alpha9) && answer == 9) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.Alpha9) && answer != 9) { WrongAnswer = false; break; }

            // Level timer
            mySlider.value = TimeLevel;
            TimeLevel -= 0.003f;

            if (TimeLevel <= 0)
            {
                WrongAnswer = false;
                break;
            }
        }
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
            PlayerPrefs.SetInt("SaveScoreMathGame", highScore);
        }
    }

    // Reset logs
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScoreMathGame");
        highScore = 0;
    }
}
