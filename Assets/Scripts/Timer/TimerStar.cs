using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerStar : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;

    public GameObject timerStar12Canvas;
    //  public AddBonusGost _gost;
    // public AddBonusSandTime _sand;

    public float _timeLeft = 0f;
    private bool _timerOn = false;

    public static Action<bool> onStarTimer;




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

                Star(_timerOn);

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

        _timeLeft = _time;
        _timerOn = true;
        timerStar12Canvas.SetActive(true);
    }

    public void TimerEnd()
    {
        _timeLeft = _time;
        _timerOn = false;
        timerStar12Canvas.SetActive(false);
    }


    private void OnEnable()
    {
        BirdFly.onTouchedStar += Star;

    }
    private void OnDisable()
    {
        BirdFly.onTouchedStar -= Star;

    }

    private void Star(bool stari)
    {
        if (_timerOn != false)
        {
            // Debug.Log("бонус Sand действует");
            //таймер для способности
            onStarTimer?.Invoke(_timerOn);
            //  sandi = false;
        }


    }
}
