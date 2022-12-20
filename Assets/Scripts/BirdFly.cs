using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdFly :MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Shooting shooting;
    public TimerSand timerSand12;
    public TimerGost timerGost12;
    public TimerBullet timerBullet12;
    [SerializeField] float velocity = 3;

    bool contactNorm = true;
    bool bulletEnd = true;
    bool speedNorm = true;

    private Rigidbody2D rigidbody;
    int playerObject, obstacleObject;


    public static Action<bool> onTouchedSand;
    bool sandi = true;
    public static Action<bool> onTouchedGost;
    bool gosti = true;
    public static Action<bool> onTouchedBullet;
    bool bulli = true;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerObject = LayerMask.NameToLayer("Player");
        obstacleObject = LayerMask.NameToLayer("Obstacle");
    }
    private void Update()
    {
        Fly(velocity);
        Contact(true);
        BonusBulletEnd(true);
    }


    public void Fly(float velocity)
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
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
            gameManager.GameOver();
        }

        if (collision.TryGetComponent(out AddBonusGost bonusGost))
        {
            onTouchedGost?.Invoke(gosti);
           timerGost12.TimerStart();
            bonusGost.Break();

            timerSand12.TimerEnd();
            timerBullet12.TimerEnd();
        }

        if (collision.TryGetComponent(out AddBonusSandTime bonusSandTime))
        {
            onTouchedSand?.Invoke(sandi);
            timerSand12.TimerStart();
            bonusSandTime.Break();

            timerGost12.TimerEnd();
            timerBullet12.TimerEnd();
        }

        if (collision.TryGetComponent(out AddBonusBullet bonusBulletTime))
        {
            onTouchedBullet?.Invoke(bulli);
            timerBullet12.TimerStart();
            bonusBulletTime.Break();

            timerGost12.TimerEnd();
            timerSand12.TimerEnd();
        }
    }

   

    private void OnEnable()
    {
        
        TimerGost.onGostTimer += BonusedGost;
        TimerBullet.onBulletTimer += BonusedBullet;
    }
    private void OnDisable()
    {
        
        TimerGost.onGostTimer -= BonusedGost;
        TimerBullet.onBulletTimer -= BonusedBullet;
    }

    private void BonusedGost(bool bonusUp)
    {
        if (bonusUp == true )
        {
            contactNorm = false;
            Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, true);
        }
    }


    private void Contact(bool contactNorm)
    {
        if (contactNorm == true)
        {
            contactNorm = true;
            Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, false);
        }
    }

    private void BonusedBullet(bool bonusUp)
    {
        if (bonusUp == true)
        {
            bulletEnd = false;
            shooting.Shoot();
        }
    }


    private void BonusBulletEnd(bool bulletEnd)
    {
        if (bulletEnd == true)
        {
            bulletEnd = true;
        }
    }




}
