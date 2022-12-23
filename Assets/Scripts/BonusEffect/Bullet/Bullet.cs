using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
       
    }


    private void Update()
    {
        rigidbody.velocity = Vector2.right * _speed;
        
         Destroy(gameObject, 2);
        Debug.Log("Vipolnenie bulett update");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Vipolnenie bulett");
        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.Break();
            Destroy(gameObject);
            Debug.Log("Vipolnenie bulett");
        }
    }
    
}
