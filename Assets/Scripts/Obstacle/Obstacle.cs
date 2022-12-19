using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    //public float speedLow;

   // [SerializeField] private NastroykaTest _nastroyka;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnPointBonus;
    [SerializeField] private Transform _spawnPointScet;
    public Transform SpawnPoint => _spawnPoint;
    public Transform SpawnPointBonus => _spawnPointBonus;
    public Transform SpawnPointScet => _spawnPointScet;

    bool speedNorm=true;

    void Start()
    {
        
    }

    
    void Update()
    {
       transform.position += Vector3.left *( speed)* Time.deltaTime;
        
        Speed(speedNorm);
        Destroy(gameObject,15);
        
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
            //Debug.Log("бонус Sand действует  на обстакле");
            speed = 0.5f;
            speedNorm = false;
        }
    }


        private void Speed(bool speedNorm)
        {
            if (speedNorm==true)
            {
               speed = 1f;
            }
            speedNorm = true;
        }


}




