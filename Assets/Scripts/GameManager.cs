using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject pipesUpdateCanvas;
    public GameObject lifeUpdateCanvas;
    public GameObject coinsUpdateCanvas;
    public GameObject startSceneCanvas;

    private void Start()
    {
       
        CountingNotActive();
        //Time.timeScale = 0;

    }

    private void Update()
    {
        //for (int i = 0; i < 1; i++)
        //{ 
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        Debug.Log("timerend");
        //       startSceneCanvas.SetActive(true);
        //       Time.timeScale = 0;
        //    }
        //    else
        //    {
        //        Time.timeScale = 1;
        //      Debug.Log("timer");
               
        //    }

        //}
       
        CountingActive();
        startSceneCanvas.SetActive(false);
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

    private void CountingActive()
    {
        pipesUpdateCanvas.SetActive(true);
        lifeUpdateCanvas.SetActive(true);
        coinsUpdateCanvas.SetActive(true);
    }

    private void CountingNotActive()
    {
        pipesUpdateCanvas.SetActive(false);
        lifeUpdateCanvas.SetActive(false);
        coinsUpdateCanvas.SetActive(false);
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
