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
    public TimerSand timerSand12;
    public TimerGost timerGost12;
    public TimerBullet timerBullet12;
    public TimerSnow timerSnow12;
    public TimerSmall timerSmall12;
    public TimerEye timerEye12;
    public TimerStar timerStar12;
    public TimerGrow timerGrow12;
    public TimerLight timerLight12;
    
   

    bool contactNorm = true;
    bool bulletEnd = true;
    bool snowEnd = true;
    bool smallEnd = true;
    bool starEnd = true;
    bool growEnd = true;
   // bool lightEnd = true;

    private Rigidbody2D rigidbody;
    private Transform transform;
    private float _timerAfterGrow;
    int playerObject, obstacleObject;
   


    public static Action<bool> onTouchedSand;
    bool sandi = true;
    public static Action<bool> onTouchedGost;
    bool gosti = true;
    public static Action<bool> onTouchedBullet;
    bool bulli = true;
    public static Action<bool> onTouchedSnow;
    bool snowi = true;
    public static Action<bool> onTouchedSmall;
    bool smalli = true;
    public static Action<bool> onTouchedEye;
    bool eyei = true;
    public static Action<bool> onTouchedStar;
    bool stari = true;
    public static Action<bool> onTouchedLight;
    bool lighti = true;
    public static Action<bool> onTouchedGrow;
    bool growi = true;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        playerObject = LayerMask.NameToLayer("Player");
        obstacleObject = LayerMask.NameToLayer("Obstacle");
       // life = 1;
    }
    private void Update()
    {
         Fly(_velocity);
         Contact();
         BonusBulletEnd();
         BonusSnowEnd();
         BonusStarEnd();
         BonusSmallEnd();
         BonusGrowEnd();
        
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
            if (GrowBox.growi==1)
            {
                LifeBox.life++;
                obstacle.Break();
            }
            
            
            LifeBox.life--;

            if (LifeBox.life == 0)
            {
                TimerBonusEnd();
                _gameManager.GameOver();
            }
        }

        if (collision.TryGetComponent(out AddBonusGost bonusGost))
        {
            TimerBonusEnd();
            onTouchedGost?.Invoke(gosti);
            timerGost12.TimerStart();
            bonusGost.Break();
        }

        if (collision.TryGetComponent(out AddBonusSandTime bonusSandTime))
        {
            TimerBonusEnd();
            onTouchedSand?.Invoke(sandi);
            timerSand12.TimerStart();
            bonusSandTime.Break();

        }


        if (collision.TryGetComponent(out AddBonusLight bonusLightTime))
        {
            TimerBonusEnd();
            onTouchedLight?.Invoke(lighti);
            timerLight12.TimerStart();
            bonusLightTime.Break();

        }

        if (collision.TryGetComponent(out AddBonusBullet bonusBulletTime))
        {
            TimerBonusEnd();
            onTouchedBullet?.Invoke(bulli);
            timerBullet12.TimerStart();
            bonusBulletTime.Break();
        }


        if (collision.TryGetComponent(out AddBonusLife bonusLife))
        {
            bonusLife.Break();
        }


        if (collision.TryGetComponent(out AddBonusSnow bonusSnowTime))
        {
            
            TimerBonusEnd();
            onTouchedSnow?.Invoke(snowi);
            timerSnow12.TimerStart();
            bonusSnowTime.Break();

            //timerGost12.TimerEnd();
            //timerBullet12.TimerEnd();
            //timerSand12.TimerEnd();
            //timerSmall12.TimerEnd();
           
        }

        if(collision.TryGetComponent(out AddBonusSmall bonusSmallTime))
        {
            TimerBonusEnd();
            onTouchedSmall?.Invoke(smalli);
            timerSmall12.TimerStart();
            bonusSmallTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusGrow bonusGrowTime))
        {
           //  GrowBox.growi++;
            if (GrowBox.growi == 0 && growEnd)
            {
                GrowBox.growi++;
            }
            TimerBonusEnd();
            onTouchedGrow?.Invoke(growi);
            timerGrow12.TimerStart();
            bonusGrowTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusEye bonusEyeTime))
        {
            TimerBonusEnd();
            onTouchedEye?.Invoke(eyei);
            timerEye12.TimerStart();
            bonusEyeTime.Break();
        }

        if (collision.TryGetComponent(out AddBonusStar bonusStarTime))
        {
            TimerBonusEnd();
            if (StarBox.stari == 0 && starEnd)
            {
                StarBox.stari++;
                 StarBox.stari--;
            }
           // if (starEnd)
            {
               // _orbiting.BuildStar();

            }
           
            onTouchedStar?.Invoke(stari);
            timerStar12.TimerStart();
            bonusStarTime.Break();
        }



    }

   

    private void OnEnable()
    {
        TimerGost.onGostTimer += BonusedGost;
        TimerBullet.onBulletTimer += BonusedBullet;
        TimerSnow.onSnowTimer += BonusedSnow;
        TimerStar.onStarTimer += BonusedStar;
        TimerSmall.onSmallTimer += BonusedSmall;
        TimerGrow.onGrowTimer += BonusedGrow;

    }
    private void OnDisable()
    {
        TimerGost.onGostTimer -= BonusedGost;
        TimerBullet.onBulletTimer -= BonusedBullet;
        TimerSnow.onSnowTimer -= BonusedSnow;
        TimerStar.onStarTimer -= BonusedStar;
        TimerSmall.onSmallTimer -= BonusedSmall;
        TimerGrow.onGrowTimer -= BonusedGrow;
    }

    private void BonusedGost(bool bonusUp)
    {
        if (bonusUp )
        {
          //  Debug.Log("gost");
            contactNorm = false;
            Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, true);
        }
        contactNorm = true;
    }


    private void Contact()
    {
        if (this.contactNorm)
        {
            contactNorm = true;
            Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, false);
          //  Debug.Log("gostend");
        }
    }

    /////
    
    private void BonusedBullet(bool bonusUp)
    {
        if (bonusUp)
        {
            bulletEnd = false;
            _shooting.Shoot();
        }
        bulletEnd = true;
    }


    private void BonusBulletEnd()
    {
        if (this.bulletEnd)
        {
            bulletEnd = true;
        }
    }

    private void BonusedGrow(bool bonusUp)
    {
        if (bonusUp)
        {
             growEnd = false;
            transform.localScale = new Vector3(_growing, _growing, _growing);
           
        }
        growEnd = true;
    }


    private void BonusGrowEnd()
    {
        if (this.growEnd)
        {
            growEnd = true;
            transform.localScale = new Vector3(_normaling, _normaling, _normaling);
        }
    }



    private void BonusedSnow(bool bonusUp)
    {
        if (bonusUp!=false)
        {
            snowEnd = false;
            Time.timeScale=_howSlow;
            Time.fixedDeltaTime = Time.timeScale * 0.015f;
           // Debug.Log("Snow");
        }
        snowEnd = true;
       // Time.timeScale = 1;
    }


    private void BonusSnowEnd()
    {
        if (snowEnd == true && LifeBox.life != 0)
        {
            Time.timeScale = 1;
            snowEnd = true;
        }


    }

    private void BonusedSmall(bool bonusUp)
    {
        if (bonusUp != false)
        {
            smallEnd = false;
            transform.localScale = new Vector3(_smalling, _smalling, _smalling);
        }
        smallEnd = true;
        // Time.timeScale = 1;
    }


    private void BonusSmallEnd()
    {
        if (this.smallEnd)
        {
            transform.localScale = new Vector3(_normaling, _normaling, _normaling);
            smallEnd = true;
        }


    }

    private void BonusedStar(bool bonusUp)
    {
        if (bonusUp != false)
        {
            starEnd = false;
           // if (StarBox.stari == 1 && Input.GetMouseButtonDown(0))
          //  {
                _orbiting.BuildStar();
                StarBox.stari--;
                //for (int i = 0; i < 1; i++)
                //{
                //    // Fly(_velocity);
                //    _staring.Fly(_velocity);
                //}
           // }
            
        }
        starEnd = true;
        // Time.timeScale = 1;
    }


    private void BonusStarEnd()
    {
        if (this.starEnd)
        {
            
            starEnd = true;
        }


    }

    //private void BonusedLight(bool bonusUp)
    //{
    //    if (bonusUp)
    //    {
    //        lightEnd = false;
            

    //    }
    //    lightEnd = true;
    //}
    private void TimerBonusEnd()
    {
        timerGost12.TimerEnd();
        timerBullet12.TimerEnd();
        timerSand12.TimerEnd();
        timerSnow12.TimerEnd();
        timerSmall12.TimerEnd();
        timerStar12.TimerEnd();
        timerGrow12.TimerEnd();
        timerLight12.TimerEnd();
    }

    
}
