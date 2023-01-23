using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    private float Speed;
    float koefSand = 0.5f;
    float koefLight = 2f;

    private UnityEngine.Object explosion;
    //public float speedLow;

    // [SerializeField] private NastroykaTest _nastroyka;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnPointBonus;
    [SerializeField] private Transform _spawnPointScet;
    [SerializeField] private Transform _spawnPointBreak;
    public Transform SpawnPoint => _spawnPoint;
    public Transform SpawnPointBonus => _spawnPointBonus;
    public Transform SpawnPointScet => _spawnPointScet;

    bool speedNorm=true;

    private void Start()
    {
        explosion = Resources.Load("ExplosionObstacle");
    }


    void Update()
    {
       transform.position += Vector3.left * Speed* Time.deltaTime;
        
        SpeedNorm();
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

        if (LightBox.lighti == 1)
        {
            Break();
        }

    }

    private void OnEnable()
    {
        TimerSand.onSandTimer += BonusedSand;
        TimerLight.onLightTimer += BonusedLight;
    }
    private void OnDisable()
    {
        TimerSand.onSandTimer -= BonusedSand;
        TimerLight.onLightTimer -= BonusedLight;
    }

    public void Break()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = _spawnPointBreak.position; //new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        Destroy(gameObject);
        Destroy(explosionRef, 1);
    }

   
  

    private void BonusedSand(bool bonusUp)
    {
        if (bonusUp)
        {
            //Debug.Log("бонус Sand действует  на обстакле");
            Speed = speed * koefSand;
            speedNorm = false;
        }
        speedNorm = true;
    }


        private void SpeedNorm()
        {
            if (this.speedNorm)
            {
               Speed = speed;
            }
            speedNorm = true;
        }

    private void BonusedLight(bool bonusUp)
    {
        if (bonusUp == true)
        {

            Speed = speed * koefLight;
            speedNorm = false;
        }
        speedNorm = true;
    }
}




