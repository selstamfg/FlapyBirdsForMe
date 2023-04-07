using System;
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

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnPointBonus;
    [SerializeField] private Transform _spawnPointScet;
    [SerializeField] private Transform _spawnPointBreak;
    public Transform SpawnPoint => _spawnPoint;
    public Transform SpawnPointBonus => _spawnPointBonus;
    public Transform SpawnPointScet => _spawnPointScet;

    public static Action onTouchedGameOver;

    private void Start()
    {
        explosion = Resources.Load("ExplosionObstacle");
    }


    void Update()
    {
       transform.position += Vector3.left * Speed* Time.deltaTime;

        BonusedSandiLight();
        Destroy(gameObject,15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  Debug.Log("OnTriggerEnter2D");

        if (collision.gameObject.tag == "Player")
        {
          //  Debug.Log("TagPlayer");
            LifeBox.life--;


            if (PlayerPrefs.GetInt("BonusGrow") == 1)
            {
                LifeBox.life++;
                Break();
            }

            if (PlayerPrefs.GetInt("BonusLight") == 1)
            {
                LifeBox.life++;
                Break();
            }



            if (LifeBox.life > 0)
            {
                Break();
            }

            if (LifeBox.life <= 0)
            {
                onTouchedGameOver?.Invoke();
            }

        }
        else
        {
            //Debug.Log("Collision object does not have Player tag");
        }
    }
    

    public void Break()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = _spawnPointBreak.position; //new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        Destroy(gameObject);
        Destroy(explosionRef, 1);
    }

    private void BonusedSandiLight()
    {
        if (PlayerPrefs.GetInt("BonusSand") == 1)
        {
            Speed = speed * koefSand;
        }
        else if ((PlayerPrefs.GetInt("BonusLight") == 1))
        {
            Debug.Log("LightObstacle");
            Speed = speed * koefLight;
        }
        else
        {
            Speed = speed;
        }
    }
}




