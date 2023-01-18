using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    [SerializeField] private float speed=1f;
    [SerializeField] private int _id;
    [SerializeField] private Vector2Int _chances;
    private float Speed;
    float koefSand = 0.5f;
    float koefLight = 2f;
    bool speedNorm = true;
    private int _bonusSize;

    int bulletObject, boxObject;

    private void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        boxObject = LayerMask.NameToLayer("Box");
    }

    public int GetId
    {
        get => _id;
    }

    public Vector2Int GetChances
    {
        get => _chances;
    }

    //void Update()
    //{
    //    SpeedNorm();
    //    transform.position += Vector3.left * Speed  * Time.deltaTime;
    //    Destroy(gameObject, 15);

    //    Physics2D.IgnoreLayerCollision(bulletObject, boxObject, true);
    //}



    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        Destroy(gameObject, 15);
        SpeedNorm();
        Physics2D.IgnoreLayerCollision(bulletObject, boxObject, true);
    }
    public void Break()
    {
        // ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        // renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        TimerSand.onSandTimer += BonusedSand;
        TimerLight.onLightTimer += BonusedLight;
    }
    private void OnDisable()
    {
        TimerSand.onSandTimer -= BonusedSand;
        TimerLight.onLightTimer -= BonusedLight;
    }

    private void BonusedSand(bool bonusUp)
    {
        if (bonusUp == true)
        {
            //  Debug.Log("бонус Sand действует  на обстакле");
            //таймер для способности
            //  transform.position += Vector3.left * speedLow * Time.deltaTime;
            Speed = speed * koefSand;
            speedNorm = false;
        }
        speedNorm = true;
    }


    private void SpeedNorm()
    {
        if (this.speedNorm)
        {
            // transform.position += Vector3.left * speed * Time.deltaTime;
            Speed = speed;
            speedNorm = true;
            // Debug.Log("бонус Sand ne действует  на обстакле");
        }
    }

    private void BonusedLight(bool bonusUp)
    {
        if (bonusUp == true)
        {
            //  Debug.Log("бонус Sand действует  на обстакле");
            //таймер для способности
            //  transform.position += Vector3.left * speedLow * Time.deltaTime;
            Speed = speed * koefLight;
            speedNorm = false;
        }
        speedNorm = true;
    }
}
