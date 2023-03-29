using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSmall : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;

    public GameObject timerSmall12Canvas;

    public float _timeLeft = 0f;
    private bool _timerOn = false;




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
                // Debug.Log("таймер остановился");
            }
        }

    }

    public void TimerStart()
    {
        //  Debug.Log("timergrow");
        // GrowBox.growi++;
        PlayerPrefs.SetInt("BonusSmall", 1);
        _timeLeft = _time;
        _timerOn = true;
        timerSmall12Canvas.SetActive(true);
    }

    public void TimerEnd()
    {
        // Debug.Log("timerEndgrow");
       
        _timeLeft = _time;
        _timerOn = false;
        timerSmall12Canvas.SetActive(false);
        PlayerPrefs.SetInt("BonusSmall", 0); 
        //  GrowBox.growi--;
    }


    private void OnEnable()
    {
        BirdFly.onTouchedSmall += Small;

    }
    private void OnDisable()
    {
        BirdFly.onTouchedSmall-= Small;

    }

    private void Small()
    {
        TimerStart();
        //  if (_timerOn != false)
        // {
        // Debug.Log("бонус Sand действует");
        //таймер для способности
        //     onGrowTimer?.Invoke(_timerOn);
        //  sandi = false;
        // }


    }
}
