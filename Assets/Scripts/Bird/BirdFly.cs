using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdFly :MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameManager _gameManager;
    [SerializeField] float _velocity;
    [Header("Script Bonused on Bird")]
    [SerializeField] float _howSlow = 0.5f;
    [SerializeField] Shooting _shooting;
    [SerializeField] SpawnStarPoint _orbiting;
    [SerializeField] Staring _staring;
    [SerializeField] float _growing;
    [SerializeField] float _smalling;
    [SerializeField] float _normaling;
    [Header("Timer Bonused")]
   
    
    private Rigidbody2D rigidbody;
    private Transform transform;
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
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        playerObject = LayerMask.NameToLayer("Player");
        obstacleObject = LayerMask.NameToLayer("Obstacle");
       // life = 1;
    }
    private void Update()
    { 
        Fly(_velocity);
        BonusedSnow();
        BonusedGost();
        BonusedGrowiSmall();
        BonusedBullet();
        BonusedStar();
    }


    public void Fly(float velocity)
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
            //circleCollider.radius = 1;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box box))
        {
            box.Break();
        }

        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            // gameManager.GameOver();
            if (PlayerPrefs.GetInt("BonusGrow") == 1)
            {
                LifeBox.life++;
                obstacle.Break();
            }

            if (PlayerPrefs.GetInt("BonusLight") == 1)
            {
                LifeBox.life++;
                obstacle.Break();
            }

            LifeBox.life--;

            if (LifeBox.life == 0)
            {
                //TimerBonusEnd();
                _gameManager.GameOver();
            }
        }

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
            //  GrowBox.growi++;
            //if (GrowBox.growi == 0 && PlayerPrefs.GetInt("BonusGrow") == 0)
            //{
            //    GrowBox.growi++;
            //}
            TimerBonusEnd();
            onTouchedGrow?.Invoke();
            bonusGrowTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusLight bonusLightTime))
        {
            //if (LightBox.lighti == 0 && PlayerPrefs.GetInt("BonusLight") == 0)
            //{
            //    LightBox.lighti++;
            //}
            Debug.Log("Ydar s Light");
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
            //if (StarBox.stari == 0 && PlayerPrefs.GetInt("BonusStar")==0)
            //{
            //    StarBox.stari++;
            //     StarBox.stari--;
            //}
            onTouchedStar?.Invoke();
            _orbiting.BuildStar();
            bonusStarTime.Break();
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
        if (PlayerPrefs.GetInt("BonusGrow") == 1)
        {
            transform.localScale = new Vector3(_growing, _growing, _growing);
        }
        else if((PlayerPrefs.GetInt("BonusSmall") == 1))
        {
            transform.localScale = new Vector3(_smalling, _smalling, _smalling);
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

    private void BonusedStar()
    {
        if (PlayerPrefs.GetInt("BonusStar") == 1)
        {
           // _orbiting.BuildStar();
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
