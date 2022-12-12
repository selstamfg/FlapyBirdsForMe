using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdFly : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] float velocity = 1;

    private Rigidbody2D rigidbody;

    //[SerializeField] private ParticleSystem _destroyEffect;



    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Debug.Log("GameObject1 collided with " + obstacle.name);
            gameManager.GameOver();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box bonus))
        {
            // BonusBox._bonus++;
            // BonusCollected?.Invoke(bonus.Collect());
           // ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
            bonus.Break();
        }


    }



}
