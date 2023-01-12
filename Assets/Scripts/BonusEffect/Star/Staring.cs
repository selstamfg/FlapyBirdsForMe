using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staring : MonoBehaviour
{
    [SerializeField] float velocity;
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.Break();
        }

        if (collision.TryGetComponent(out Box box))
        {
            box.Break();
        }

    }



}
