using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdFly :MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public TimerLight timer12;
    [SerializeField] float velocity = 3;
  
    public AddBonusGost _gost;

    private Rigidbody2D rigidbody;
    int playerObject, obstacleObject;




    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        playerObject = LayerMask.NameToLayer("Player");
        obstacleObject = LayerMask.NameToLayer("Obstacle");
    }
    private void Update()
    {
        Fly(velocity);
    }


    public void Fly(float velocity)
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
        }

    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
    //    {
    //        Debug.Log("GameObject1 collided with " + obstacle.name);
    //        gameManager.GameOver();
    //    }

    //}

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
            timer12.TimerStart();
            bonusGost.Break();
            
        }

        if (collision.TryGetComponent(out AddBonusSandTime bonusSandTime))
        {
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

    public void SandTime()
    {

        if (timer12._timeLeft > 0)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }


    }
}
