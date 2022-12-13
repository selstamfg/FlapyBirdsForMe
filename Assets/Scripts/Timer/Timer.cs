using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 20f;
    float timeLeft;
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    
    void Update()
    {
        if (timeLeft>0)
        {
            timeLeft -= Time.deltaTime;
           timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
