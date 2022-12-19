using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private float speed;
   // public float speedLow;
    bool speedNorm = true;
    // [SerializeField] GameManager _gameManager;
    //  [Header("Gost Bonus")]
    //  [SerializeField] private AddBonusGost _bonusGostTemplates;


    private void Start()
    {
       
    }


    void Update()
    {
        transform.position += Vector3.left * (speed ) * Time.deltaTime;
        Destroy(gameObject, 15);
       Speed(speedNorm);
    }
    private void OnEnable()
    {
        TimerSand.onSandTimer += BonusedSand;
    }
    private void OnDisable()
    {
        TimerSand.onSandTimer -= BonusedSand;
    }

    private void BonusedSand(bool bonusUp)
    {
        if (bonusUp == true)
        {
            //  Debug.Log("бонус Sand действует  на обстакле");
            //таймер для способности
            //  transform.position += Vector3.left * speedLow * Time.deltaTime;
            speed = 0.5f;
            speedNorm = false;

        }
    }


    private void Speed(bool speedNorm)
    {
        if (speedNorm == true)
        {
          // transform.position += Vector3.left * speed * Time.deltaTime;
            speed = 1f;
            // Debug.Log("бонус Sand ne действует  на обстакле");
        }
        speedNorm = true;

    }


}
