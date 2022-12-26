using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] bool _zoomActive;
    [SerializeField] Camera _Camera2D;
    [SerializeField] float _Speed;
    [SerializeField] float _ZoomSize;
    [SerializeField] bool _isZoom = false;

    public TimerEye timerEye12;
    bool eyeEnd = true;


    private void Start()
    {
        _Camera2D = Camera.main;
    }

    private void Update()
    {
       UpdatePosition();

        BonusEyeEnd();
    }

   private void UpdatePosition()
   {
       // if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isZoom==false)
            {
                _zoomActive = true;
                _isZoom = true;
            }
            else
            {
                _zoomActive = false;
                _isZoom = false;
            }
        }
   }


    private void OnEnable()
    {
       
        TimerEye.onEyeTimer += BonusedEye;

    }
    private void OnDisable()
    {
        
        TimerEye.onEyeTimer -= BonusedEye;
    }

    private void BonusedEye(bool bonusUp)
    {
        if (bonusUp != false)
        {
            eyeEnd = false;
            UpdatePosition();
        }
        eyeEnd = true;
    }


    private void BonusEyeEnd()
    {
        if (eyeEnd == true)
        {
            eyeEnd = true;
        }


    }



    public void LateUpdate()
    {
        if (_zoomActive)
        {
            _Camera2D.orthographicSize = Mathf.Lerp(_Camera2D.orthographicSize, _ZoomSize, _Speed);
        }
        else
        {
            _Camera2D.orthographicSize = Mathf.Lerp(_Camera2D.orthographicSize,5.12f,_Speed);

        }
    }

}
