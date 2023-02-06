using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
   
   

    public void  GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    //private void CountingActive()
    //{
    //    pipesUpdateCanvas.SetActive(true);
    //    lifeUpdateCanvas.SetActive(true);
    //    coinsUpdateCanvas.SetActive(true);
    //}

    //private void CountingNotActive()
    //{
    //    pipesUpdateCanvas.SetActive(false);
    //    lifeUpdateCanvas.SetActive(false);
    //    coinsUpdateCanvas.SetActive(false);
    //}

    //public void TimerLight12()
    //{
    //    timer12Canvas.SetActive(true);


    //}

    //public void ReloadTimer12()
    //{
    //    timer12Canvas.SetActive(false);
    //}
}
