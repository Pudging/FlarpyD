using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public static int difficulty = 0;
    private void Start()
    {
        
            SceneManager.UnloadSceneAsync("GameScene");
        
        difficulty = 0;

    }
    public void StartGameNormal() {
        SceneManager.LoadScene(1);
        difficulty = 0;
    }
    public void StartGameHard()
    {
        SceneManager.LoadScene(1);
        difficulty = 1;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
