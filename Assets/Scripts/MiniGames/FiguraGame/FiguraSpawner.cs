using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiguraSpawner : MonoBehaviour
{
    public static FiguraSpawner instance;

    public List<GameObject> FiguraList;
    public int health;
    public int numOfHearts;
    public Image ColorBackFigura;
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

    public int tmp = 0;
    public GameObject RestartMenu;
    public int temp = 0;
    int colorIndex = 0;
    public int FiguraIndex;
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
        if (PlayerPrefs.HasKey("SaveScoreFiguraGame"))
        {
            highScore = PlayerPrefs.GetInt("SaveScoreFiguraGame");
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
        ColorBackFigura.color = colorList[colorIndex];

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
            while (colorIndex == tempColorIndex)
            {
                colorIndex = Random.Range(0, 8);
            }
            tempColorIndex = colorIndex;
            StartCoroutine(Spawner());
        }

        Debug.Log(ClickScript.ClickArea);
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator Spawner()
    {
        WrongAnswer = true;
        while (temp == FiguraIndex)
        {
            FiguraIndex = Random.Range(0, 4);
        }
        temp = FiguraIndex;
        GameObject figura = Instantiate(FiguraList[FiguraIndex], new Vector2(460f, 250f), Quaternion.identity);
        while (true)
        {
            yield return new WaitForSeconds(0);

            if (Input.GetKeyDown(KeyCode.UpArrow))
                Debug.Log("Up Arrow key was pressed.");

            if (Input.GetKeyDown(KeyCode.UpArrow) && FiguraIndex == 0) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && FiguraIndex != 0) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.DownArrow) && FiguraIndex == 1) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && FiguraIndex != 1) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.RightArrow) && FiguraIndex == 2) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && FiguraIndex != 2) { WrongAnswer = false; break; }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && FiguraIndex == 3) { RightAnswer = true; break; }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && FiguraIndex != 3) { WrongAnswer = false; break; }

            // Level timer
            mySlider.value = TimeLevel;
            TimeLevel -= 0.005f;

            if (TimeLevel <= 0)
            {
                WrongAnswer = false;
                break;
            }
        }
        Destroy(figura);
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
            PlayerPrefs.SetInt("SaveScoreFiguraGame", highScore);
        }
    }

    // Reset logs
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScoreFiguraGame");
        highScore = 0;
    }
}
