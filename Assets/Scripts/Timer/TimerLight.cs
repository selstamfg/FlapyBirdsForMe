using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLight : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Text _timerText;
    [SerializeField] private Image timerImage1;
    
    public GameObject timer12Canvas;
  //  public AddBonusGost _gost;
   // public AddBonusSandTime _sand;

    public float _timeLeft = 0f;
    private bool _timerOn = false;

    public static Action<bool> onSandTimer;
    public static Action<bool> onGostTimer;
    private bool preassureNorm= true;


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

               // Sand(false);
                Gost(preassureNorm);

                var normalizedValue1 = Mathf.Clamp(_timeLeft / _time, 0.0f, 1.0f);
                timerImage1.fillAmount = normalizedValue1;

            }
            else
            {
               _timeLeft = _time;
                _timerOn = false;
                timer12Canvas.SetActive(false);
               // Debug.Log("таймер остановился");
               
            }
           
        }
        
    }
   
    public void TimerStart()
    {

        _timeLeft = _time;
        _timerOn = true;
        timer12Canvas.SetActive(true);
    }


    private void OnEnable()
    {
        BirdFly.onTouchedSand += Sand;
        BirdFly.onTouchedGost += Gost;
    }
    private void OnDisable()
    {
        BirdFly.onTouchedSand -= Sand;
       BirdFly.onTouchedGost -= Gost;
    }

    private void Sand(bool sandi)
    {
        if( _timerOn==true)
        {
           // Debug.Log("бонус Sand действует");
            //таймер для способности
            onSandTimer?.Invoke(_timerOn);
          //  sandi = false;
        }
       
      
    }

    //private void Gost(bool booli)
    //{
    //    if ( _timerOn == true && booli==true)
    //    {
    //       // Debug.Log("бонус Gost действует");
    //        //таймер для способности
    //        onGostTimer?.Invoke(_timerOn);

    //    }


    //}
   
    private void Gost(bool colision)
    {
        if (colision == true && _timerOn==true)
        {
            Debug.Log("бонус Gost действует  ");
            //таймер для способности
            preassureNorm = false;
            onGostTimer?.Invoke(colision);
        }
    }


    private void Speed(bool pressureNorm)
    {
        if (pressureNorm == true)
        {
            pressureNorm = true;
            Debug.Log("бонус Gost ne действует  ");
        }


    }
}    
