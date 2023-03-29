using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSand : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;
    
    public GameObject timerSand12Canvas;

    public float _timeLeft = 0f;
    private bool _timerOn = false;

   // public static Action onSandTimer;
    
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
            }
        }
    }
   
    public void TimerStart()
    {
        PlayerPrefs.SetInt("BonusSand", 1);
        _timeLeft = _time;
        _timerOn = true;
        timerSand12Canvas.SetActive(true);
    }

    public void TimerEnd()
    {
        _timeLeft = _time;
        _timerOn = false;
        timerSand12Canvas.SetActive(false);
        PlayerPrefs.SetInt("BonusSand", 0);
    }


    private void OnEnable()
    {
        BirdFly.onTouchedSand += Sand;
    }
    private void OnDisable()
    {
        BirdFly.onTouchedSand -= Sand;
    }

    private void Sand()
    {
        TimerStart();
    }
}    
