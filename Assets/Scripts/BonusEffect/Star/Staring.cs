using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staring : MonoBehaviour
{
    [SerializeField] float velocity;
    private Transform _targetPos;
    private Rigidbody2D _rigidbody;

    public void SetTargetTransform(Transform target)
    {
        _targetPos = target;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 15);
        Fly(velocity);
    }

    public void Fly(float velocity)
    {
        if (transform.position != _targetPos.position)
            transform.position = _targetPos.position;
        //if (Input.GetMouseButtonDown(0))
        //{
        //rigidbody.velocity = Vector2.up * velocity;
        //}
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
