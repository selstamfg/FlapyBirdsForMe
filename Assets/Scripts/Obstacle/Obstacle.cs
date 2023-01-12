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
    
    void Update()
    {
       transform.position += Vector3.left *( speed)* Time.deltaTime;
        
        Speed();
        Destroy(gameObject,15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (LifeBox.life != 1)
        {
            Break();
        }

        if (GrowBox.growi == 1)
        {
            Break();
        }

    }

    private void OnEnable()
    {
        TimerSand.onSandTimer += BonusedSand;
    }
    private void OnDisable()
    {
        TimerSand.onSandTimer -= BonusedSand;
    }

    public void Break()
    {
        Destroy(gameObject);
    }

    private void BonusedSand(bool bonusUp)
    {
        if (bonusUp)
        {
            //Debug.Log("бонус Sand действует  на обстакле");
            speed = 0.5f;
            speedNorm = false;
        }
        speedNorm = true;
    }


        private void Speed()
        {
            if (this.speedNorm)
            {
               speed = 1f;
            }
            speedNorm = true;
        }

    
}




