using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Text _scoreText;
    public int _score;
    public float _time;
    private float _timeStart;
   
    void Update()
    {
        _time -= Time.deltaTime;
        if (_time<=0)
        {
           // ScoreManager._score += 1;
            _time = _timeStart;
        }
    }
}
