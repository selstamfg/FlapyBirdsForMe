using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;
    [SerializeField] private Image timerImage2;

    private float _timeLeft = 0f;
    private bool _timerOn = false;
    private int _scet = 0;

    void Start()
    {
        _timeLeft = time;
        _timerOn = true;
    }

    
    void Update()
    {
        if (_timerOn)
        { 

            if (_timeLeft > 0 && _scet == 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();

                var normalizedValue1 = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
                timerImage1.fillAmount = normalizedValue1;
               

                if (_timeLeft==0)
                 {
                  _timeLeft = time;
                  _scet = 1;

                 }
            }
            else if (_timeLeft > 0 && _scet == 1)
            {
                

                _timeLeft -= Time.deltaTime;
                UpdateTimeText();

                var normalizedValue2 = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
                timerImage2.fillAmount = normalizedValue2;


            }
            else
            {
                _timeLeft = time;

                _timerOn = false;
            }


        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;


        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);




    }




}
