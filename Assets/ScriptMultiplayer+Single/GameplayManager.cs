using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI LeftScoreText;
    public TextMeshProUGUI RightScoreText;
    public TextMeshProUGUI timerText;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    public bool leftDoublePoint = false;
    public bool rightDoublePoint = false;

    public float timer;
    private bool gameRunning = true;

    public string endResult = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (LeftScoreText == null)
            LeftScoreText = GameObject.Find("LeftScoreText")?.GetComponent<TextMeshProUGUI>();

        if (RightScoreText == null)
            RightScoreText = GameObject.Find("RightScoreText")?.GetComponent<TextMeshProUGUI>();

        if (timerText == null)
            timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();

        timer = GMMScript.Instance.selectedTime;

        LeftScoreText.text = "0";
        RightScoreText.text = "0";
        timerText.text = timer.ToString("F1");
    }

    void Update()
{
    if (gameRunning)
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && scoreLeft != scoreRight)
        {
            timer = 0;
            Time.timeScale = 0f;  
            gameRunning = false;

            if (scoreLeft > scoreRight)
                endResult = "p1";
            else
                endResult = "p2";

            if (GMMScript.Instance.currentMode == GMMScript.Mode.SinglePlayer)
                SceneManager.LoadScene("EndSingle", LoadSceneMode.Additive);
            else
                SceneManager.LoadScene("EndMultiplayer", LoadSceneMode.Additive);
        }

        if (timer <= 0 && scoreLeft == scoreRight)
        {
            timer = 0;  
        }

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

    public void AddLeftScore()
    {
        if (leftDoublePoint)
        {
            scoreLeft += 2;
            leftDoublePoint = false;
        }
        else
        {
            scoreLeft++;
        }

        LeftScoreText.text = scoreLeft.ToString();
    }

    public void AddRightScore()
    {      
        if (rightDoublePoint)
        {
            scoreRight += 2;
            rightDoublePoint = false;
        }
        else
        {
            scoreRight++;
        }

        RightScoreText.text = scoreRight.ToString();
    }
}