using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSnow : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;

    public GameObject timerSnow12Canvas;

    public float _timeLeft = 0f;
    private bool _timerOn = false;

    public static Action  onSnowTimer;

    void Update()
    {
        Timer();
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;


        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void Timer()
    {
        if (_timerOn)
        {
           // Debug.Log("бонус Snow  действует");

            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
                var normalizedValue1 = Mathf.Clamp(_timeLeft / _time, 0.0f, 1.0f);
                timerImage1.fillAmount = normalizedValue1;
            }
            else
            {
                TimerEnd();
               //  Debug.Log("таймер остановился");
            }
        }
    }

    public void TimerStart()
    {
       // Debug.Log("бонус Snow start");
        PlayerPrefs.SetInt("BonusSnow", 1);
        _timeLeft = _time;
        _timerOn = true;
        timerSnow12Canvas.SetActive(true);
    }

    public void TimerEnd()
    {
       // Debug.Log("бонус Snow end действует");
        _timeLeft = _time;
        _timerOn = false;
        timerSnow12Canvas.SetActive(false);
        PlayerPrefs.SetInt("BonusSnow", 0);
    }


    private void OnEnable()
    {
        BirdFly.onTouchedSnow += Snow;
    }
    private void OnDisable()
    {
        BirdFly.onTouchedSnow -= Snow;
    }

    private void Snow()
    {
        TimerStart();
    }
}
