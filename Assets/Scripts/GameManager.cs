using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
 
    void Start()
    {
        Time.timeScale = 1;
    }

    
    public void  GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    //public void TimerLight12()
    //{
    //    timer12Canvas.SetActive(true);

       
    //}

    //public void ReloadTimer12()
    //{
    //    timer12Canvas.SetActive(false);
    //}
}
