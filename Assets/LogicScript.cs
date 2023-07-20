using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LogicScript : MonoBehaviour
{
    public Camera mCamera;
    public GameObject gameOverScreen;
    public GameObject VictoryScreen;
    public int PlayerScore;
    public Text ScoreText;
    public Text HealthText;
    public Text TimerText;
    [ContextMenu("RunScore")]
    public void addScore(int ScoreToAdd)
    {
        PlayerScore += ScoreToAdd;
        ScoreText.text = PlayerScore.ToString();
    }

    public int getScore()
    {
        return PlayerScore;
    }
    public void setHealth (int health)
    {
        HealthText.text = "Health: " + health.ToString();
    }
    public void setTimer (float time)
    {
        TimerText.text = time.ToString();
    }
    
    public void returnToMain ()
    {
        if (SceneManager.GetActiveScene() != null)
        {
            SceneManager.LoadSceneAsync("StartScene");
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        mCamera.orthographicSize = 12;
        TimerText.text = (0).ToString();
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
    }
    public void gameWon()
    {
        VictoryScreen.SetActive(true);
    }
}
