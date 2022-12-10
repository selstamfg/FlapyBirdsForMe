using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] float velocity = 1;
    private Rigidbody2D rigidbody;



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
        gameManager.GameOver();
    }

}
