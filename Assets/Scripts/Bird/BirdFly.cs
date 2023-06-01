using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BirdFly :MonoBehaviour
{
    [Header("General")]
  //  [SerializeField] GameManager _gameManager;
    [Header("Script Bonused on Bird")]
    [SerializeField] float _howSlow = 0.5f;
    [SerializeField] Shooting _shooting;
    [SerializeField] SpawnStarPoint _orbiting;
    [SerializeField] Staring _staring;
    [SerializeField] float _growing;
    [SerializeField] float _smalling;
    [SerializeField] float _normaling;
    [Header("Timer Bonused")]
   
    
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private float _timerAfterGrow;
    int playerObject, obstacleObject;
   


    public static Action onTouchedSand;
    public static Action onTouchedGost;
    public static Action onTouchedBullet;
    public static Action onTouchedSnow;
    public static Action onTouchedSmall;
    public static Action onTouchedEye;
    public static Action onTouchedStar;
    public static Action onTouchedLight;
    public static Action onTouchedGrow;


    private void Start()
    {
        TimerBonusEnd();
        //rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        playerObject = LayerMask.NameToLayer("Player");
        obstacleObject = LayerMask.NameToLayer("Obstacle");
        //Scene currentScene = SceneManager.GetActiveScene();
        //if (currentScene.name == "MenuScene")
        //{

        //    transform.localScale = new Vector3(_growing, _growing, _growing);
        //}
    }
    private void Update()
    {
        //  Fly(_velocity); 
        BonusedSnow();
        BonusedGost();
        BonusedGrowiSmall();
        BonusedBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.TryGetComponent(out AddBonusGost bonusGost))
        {
            TimerBonusEnd();
            onTouchedGost?.Invoke();
            bonusGost.Break();
        }

        if (collision.TryGetComponent(out AddBonusSandTime bonusSandTime))
        {
            TimerBonusEnd();
            onTouchedSand?.Invoke();
            bonusSandTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusBullet bonusBulletTime))
        {
            TimerBonusEnd();
            onTouchedBullet?.Invoke();
            bonusBulletTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusLife bonusLife))
        {
            bonusLife.Break();
        }

        if (collision.TryGetComponent(out AddBonusSnow bonusSnowTime))
        {
            TimerBonusEnd();
            onTouchedSnow?.Invoke();
            bonusSnowTime.Break();
        }

        if(collision.TryGetComponent(out AddBonusSmall bonusSmallTime))
        {
            TimerBonusEnd();
            onTouchedSmall?.Invoke();
            bonusSmallTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusGrow bonusGrowTime))
        {
            TimerBonusEnd();
            onTouchedGrow?.Invoke();
            bonusGrowTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusLight bonusLightTime))
        {
           //Debug.Log("Ydar s Light");
            TimerBonusEnd();
            onTouchedLight?.Invoke();
            bonusLightTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusEye bonusEyeTime))
        {
            TimerBonusEnd();
            onTouchedEye?.Invoke();
            bonusEyeTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusStar bonusStarTime))
        {
            TimerBonusEnd();
            onTouchedStar?.Invoke();
            _orbiting.BuildStar();
            bonusStarTime.Break();
        }

        if (collision.TryGetComponent(out AddMysticEgg mysticEgg))
        {
            mysticEgg.Break();
        }

    }


    private void BonusedGost()
    {
        if (PlayerPrefs.GetInt("BonusGost") == 0)
        {
            Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, false);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, true);
        }
    }
    
    private void BonusedBullet()
    {
        if (PlayerPrefs.GetInt("BonusBullet") == 1)
        {
            _shooting.Shoot();
        }
    }

    private void BonusedGrowiSmall()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (PlayerPrefs.GetInt("BonusGrow") == 1)
        {
            transform.localScale = new Vector3(_growing, _growing, _growing);
        }
        else if((PlayerPrefs.GetInt("BonusSmall") == 1))
        {
            transform.localScale = new Vector3(_smalling, _smalling, _smalling);
        }
        else if  (currentScene.name == "MenuScene")
        {
            transform.localScale = new Vector3(_growing, _growing, _growing);
        }
        else
        {
            transform.localScale = new Vector3(_normaling, _normaling, _normaling);
        }
    }

   
    private void BonusedSnow()
    {
        if (PlayerPrefs.GetInt("BonusSnow") == 0 )//&& LifeBox.life != 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = _howSlow;
            Time.fixedDeltaTime = Time.timeScale * 0.015f;
        }
    }
    
    private void TimerBonusEnd()
    {
       // Debug.Log("timerEnd");
        PlayerPrefs.SetInt("BonusGost", 0);
        PlayerPrefs.SetInt("BonusGrow", 0);
        PlayerPrefs.SetInt("BonusSmall", 0);
        PlayerPrefs.SetInt("BonusLight", 0);
        PlayerPrefs.SetInt("BonusStar", 0);
        PlayerPrefs.SetInt("BonusSand", 0);
        PlayerPrefs.SetInt("BonusBullet", 0);
    }
}
