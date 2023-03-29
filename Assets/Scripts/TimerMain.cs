using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMain : MonoBehaviour
{
    private Timers timer;
    public Transform timerPos;
    public GameObject[] timers;



    void Update()
    {
        timer = Instantiate(timers[PlayerPrefs.GetInt("Timer")], timerPos.position, Quaternion.identity).GetComponent<Timers>();
    }
}
