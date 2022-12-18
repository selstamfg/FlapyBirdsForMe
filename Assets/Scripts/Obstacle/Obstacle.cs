using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
     public float speed=1;

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
         transform.position += Vector3.left * speed* Time.deltaTime;
        
        Speed(speedNorm);

        //Speed(1);
            Destroy(gameObject,15);
        
    }
    private void OnEnable()
    {
        TimerLight.onSandTimer += BonusedSand;
    }
    private void OnDisable()
    {
        TimerLight.onSandTimer -= BonusedSand;
    }

    private void BonusedSand(bool bonusUp)
    {
        if (bonusUp == true)
        {
            Debug.Log("бонус Sand действует  на обстакле");
            //таймер для способности
            speedNorm = false;

        }
    }


        private void Speed(bool speedNorm)
        {
            if (speedNorm==true)
            {
                 speedNorm = true;
                Debug.Log("бонус Sand ne действует  на обстакле");
            }


        }


}




