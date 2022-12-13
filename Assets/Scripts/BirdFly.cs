using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdFly :MonoBehaviour
{
   [SerializeField] GameManager gameManager;
    public TimerLight timer12;
   // public AddBonusGost gost;
    [SerializeField] float velocity = 1;

    private Rigidbody2D rigidbody;

    //[SerializeField] private ParticleSystem _destroyEffect;



    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
            
           // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), box.GetComponent<Collider2D>());
            box.Break();

        }

        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            gameManager.GameOver();
            //Gost();
        }

        if (collision.TryGetComponent(out Bonus bonus))
        {
            timer12.TimerStart();
           // gost.Gost();
            bonus.Break();
            
        }

        

    }

   // private void Gost()
  //  {
      //  Rigidbody rigidbody = GetComponent<Rigidbody>();
      //  rigidbody.isKinematic = false;


  //  }

}
