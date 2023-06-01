using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _gameOverCanvas;

    public static bool replay;

    public void  GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        replay = false;
        Debug.Log("GameOver");
    }

    public void Replay()
    {
        replay = true;
        SceneManager.LoadScene(1);
    }

    public void  Menu()
    {
        
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        Obstacle.onTouchedGameOver += GameOver;
    }
    private void OnDisable()
    {
        Obstacle.onTouchedGameOver -= GameOver;
    }
}
