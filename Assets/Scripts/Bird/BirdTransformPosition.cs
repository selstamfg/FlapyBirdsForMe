using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdTransformPosition : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float _velocity;
    [SerializeField] string _movementType = "var1"; // тип передвижения по умолчанию
    [SerializeField] float _followSpeed = 10.0f; // скорость следования за пальцем для var3
    [SerializeField] float smoothTime;
    [SerializeField] float _mass;
    private Vector2 _velocityRef;
    private Rigidbody2D _rigidbody;
   // private float _normaling=1;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // SetMovementType(_movementType);
        SetMass(_mass);
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MenuScene")
        {
            _rigidbody.simulated = false;
        }
        else
        {
            _rigidbody.simulated = true;
        }


        switch (_movementType)
        {
            case "var1":
                FlyUp(_velocity);
                break;
            case "var2":
                FallUp(_velocity);
                break;
            case "var3":
                FollowFinger(_followSpeed);
                break;
            case "var4":
                FlyUpSmooth(_velocity, smoothTime);
                break;
            case "var5":
                FlyDownSmooth(_velocity, smoothTime);
                break;
            default:
                Debug.LogWarning("Unknown movement type: " + _movementType);
                break;
        }
    }

   public void SetMass(float mass)
   {
        _mass = mass;
        _rigidbody.mass = mass;

   }

    public void FlyUp(float velocity)
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * velocity;
        }
    }

    public void FallUp(float velocity)
    {
        _rigidbody.gravityScale = -1f;
        if (Input.GetMouseButtonDown(0))
        {
             _rigidbody.velocity = Vector2.down * velocity;
        }
        
    }

    public void FollowFinger(float followSpeed)
    {
        Vector2 fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = fingerPos - _rigidbody.position;
        _rigidbody.velocity = direction.normalized * followSpeed;
    }

   
    public void FlyUpSmooth(float velocity, float smoothTime)
    {
        _rigidbody.gravityScale = 0.3f;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 targetVelocity = Vector2.up * velocity;
        //    _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocityRef, smoothTime);
        //}
        if (Input.GetMouseButton(0))
        {
            float currentVelocity = _rigidbody.velocity.y;
            float targetVelocity = Mathf.Min(currentVelocity + velocity * Time.deltaTime, velocity);
            _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, Vector2.up * targetVelocity, ref _velocityRef, smoothTime);
        }
    }

    public void FlyDownSmooth(float velocity, float smoothTime)
    {
        _rigidbody.gravityScale = -0.2f;
        if (Input.GetMouseButton(0))
        {
            float currentVelocity = _rigidbody.velocity.y;
            float targetVelocity = Mathf.Min(currentVelocity + velocity * Time.deltaTime, velocity);
            _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, Vector2.up * targetVelocity, ref _velocityRef, smoothTime);
        }
    }

}