using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdFly :MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Shooting shooting;
   // [SerializeField] LifeBox lifeBox;
    public TimerSand timerSand12;
    public TimerGost timerGost12;
    public TimerBullet timerBullet12;
    public TimerSnow timerSnow12;
    public TimerSmall timerSmall12;
    public TimerEye timerEye12;
    [SerializeField] float velocity;
    [SerializeField] float HowSlow = 0.5f;

    bool contactNorm = true;
    bool bulletEnd = true;
    bool snowEnd = true;
    bool smallEnd = true;

    private Rigidbody2D rigidbody;
  //  private CircleCollider2D circleCollider;
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

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //circleCollider = GetComponent<CircleCollider2D>();
        playerObject = LayerMask.NameToLayer("Player");
        obstacleObject = LayerMask.NameToLayer("Obstacle");
       // life = 1;
    }
    private void Update()
    {
        Fly(velocity);
        Contact();
        BonusBulletEnd();
         BonusSnowEnd();
       
        
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
           LifeBox.life--;

            if (LifeBox.life == 0)
            {
                TimerBonusEnd();
                gameManager.GameOver();
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

        if (collision.TryGetComponent(out AddBonusEye bonusEyeTime))
        {
            TimerBonusEnd();
            onTouchedEye?.Invoke(eyei);
            timerEye12.TimerStart();
            bonusEyeTime.Break();
        }

    }

   

    private void OnEnable()
    {
        TimerGost.onGostTimer += BonusedGost;
        TimerBullet.onBulletTimer += BonusedBullet;
        TimerSnow.onSnowTimer += BonusedSnow;
        
    }
    private void OnDisable()
    {
        TimerGost.onGostTimer -= BonusedGost;
        TimerBullet.onBulletTimer -= BonusedBullet;
        TimerSnow.onSnowTimer -= BonusedSnow;
    }

    private void BonusedGost(bool bonusUp)
    {
        if (bonusUp )
        {
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
        }
    }

    /////
    
    private void BonusedBullet(bool bonusUp)
    {
        if (bonusUp)
        {
            bulletEnd = false;
            shooting.Shoot();
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

    private void BonusedSnow(bool bonusUp)
    {
        if (bonusUp!=false)
        {
            snowEnd = false;
            Time.timeScale=HowSlow;
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

           // transform.localScale.x = 2f;
            // Debug.Log("Snow");
        }
        smallEnd = true;
        // Time.timeScale = 1;
    }


    private void BonusSmallEnd()
    {
        if (this.snowEnd)
        {
            
            smallEnd = true;
        }


    }


    private void TimerBonusEnd()
    {
        timerGost12.TimerEnd();
        timerBullet12.TimerEnd();
        timerSand12.TimerEnd();
        timerSnow12.TimerEnd();
        timerSmall12.TimerEnd();
    }

    
}
