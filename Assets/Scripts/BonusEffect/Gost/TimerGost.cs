using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGost : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;

    public GameObject timerGost12Canvas;

    public float _timeLeft = 0f;
    private bool _timerOn = false;

    
    public static Action<bool> onGostTimer;
    private bool preassureNorm = true;


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

                Gost(_timerOn);
                
                var normalizedValue1 = Mathf.Clamp(_timeLeft / _time, 0.0f, 1.0f);
                timerImage1.fillAmount = normalizedValue1;
            }
            else
            {
               
                TimerEnd();
                // Debug.Log("������ �����������");
            }
        }
    }

    public void TimerStart()
    {   
        _timeLeft = _time;
        _timerOn = true;
        timerGost12Canvas.SetActive(true);
    }

    public void TimerEnd()
    {
        _timeLeft = _time;
        _timerOn = false;
        timerGost12Canvas.SetActive(false);

    }

    private void OnEnable()
    {
        BirdFly.onTouchedGost += Gost;
    }
    private void OnDisable()
    {
        BirdFly.onTouchedGost -= Gost;
    }



    private void Gost(bool booli)
    {
        if (_timerOn == true )
        {
            // Debug.Log("����� Gost ���������");
            onGostTimer?.Invoke(_timerOn);
        }
    }
}
