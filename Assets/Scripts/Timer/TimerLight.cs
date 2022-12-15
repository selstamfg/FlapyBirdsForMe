using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLight : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;
    [SerializeField] private BirdFly _bird;
    public GameObject timer12Canvas;
    public AddBonusGost _gost;
   // public AddBonusSandTime _sand;

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

                //  Bonused();
                _bird.Goster();
               // _bird.SandTime();

                var normalizedValue1 = Mathf.Clamp(_timeLeft / _time, 0.0f, 1.0f);
                timerImage1.fillAmount = normalizedValue1;

            }
            else
            {
               _timeLeft = _time;
                _timerOn = false;
                timer12Canvas.SetActive(false);
                
            }
           
        }
        
    }
   
    public void TimerStart()
    {

        _timeLeft = _time;
        _timerOn = true;
        timer12Canvas.SetActive(true);
    }
   
   // private void Bonused()
   // {
        //if (_sand._sandTimeOn)
        //{
        //    _bird.SandTime();

        //}
        //else
        //{
            
        //   // _bird.Goster();

        //}
       

   // }
}
