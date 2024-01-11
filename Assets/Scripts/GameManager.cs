using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Added line

public class GameManager : MonoBehaviour
{
    public float gameTimeInSeconds = 60f; // Game duration (in seconds)
    private float currentTime;

    public Text timeText; // Connect this text in the Unity Editor

    bool isGameOver = false; // Added line

    public static GameManager Instance; // Added line

    void Awake() // Added function
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
        currentTime = gameTimeInSeconds;
        UpdateTimeText();
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                GameOver(); // End the game or perform another action
            }
        }
    }

    void UpdateTimeText()
    {
        if (timeText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void GameOver()
    {
        isGameOver = true; // Added line
        Time.timeScale = 0f; // Pause the game
        Debug.Log("Game Over!");
    }

    public void LevelComplete()
    {
        isGameOver = true; // Added line
        Time.timeScale = 0f; // Pause the game
        Debug.Log("Level Completed!");

        SceneManager.LoadScene("Bolum2");
    }
}

