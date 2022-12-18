using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdFly :MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public TimerLight timer12;
    [SerializeField] float velocity = 3;

    // public AddBonusGost _gost;
    bool contactNorm = true;

    private Rigidbody2D rigidbody;
    int playerObject, obstacleObject;


    public static Action<bool> onTouchedSand;
    bool sandi = true;
    public static Action<bool> onTouchedGost;
    bool gosti = true;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        playerObject = LayerMask.NameToLayer("Player");
        obstacleObject = LayerMask.NameToLayer("Obstacle");
    }
    private void Update()
    {
        Fly(velocity);
        Contact(contactNorm);
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

           // Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, false);
            gameManager.GameOver();

           
        }

        if (collision.TryGetComponent(out AddBonusGost bonusGost))
        {
            onTouchedGost?.Invoke(gosti);
           timer12.TimerStart();
            bonusGost.Break();
            
        }

        if (collision.TryGetComponent(out AddBonusSandTime bonusSandTime))
        {
            onTouchedSand?.Invoke(sandi);
            timer12.TimerStart();
            bonusSandTime.Break();

        }


    }

    public void Goster()
    {
        if (timer12._timeLeft>0)
        {
             Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, true);
            //Debug.Log("Effect");
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerObject, obstacleObject, false);
        }
    }

    private void OnEnable()
    {
        TimerLight.onGostTimer += BonusedGost;
    }
    private void OnDisable()
    {
        TimerLight.onGostTimer -= BonusedGost;
    }

    private void BonusedGost(bool bonusUp)
    {
        if (bonusUp == true )
        {
            Debug.Log("бонус Gost действует  на Bird");
            //таймер для способности
            contactNorm = false;

        }
    }


    private void Contact(bool contactNorm)
    {
        if (contactNorm == true)
        {
            contactNorm = true;
            Debug.Log("бонус Gost ne действует  на Bird");
        }


    }
    
}
