using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private float Speed;
    float koefSand = 0.5f;
    float koefLight = 2f;
    bool speedNorm = true;
    int bulletObject,starObject, scetObject;


    private void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        starObject = LayerMask.NameToLayer("Star");
        scetObject = LayerMask.NameToLayer("Scet");
    }


    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        Destroy(gameObject, 15);
        SpeedNorm();
        Physics2D.IgnoreLayerCollision(bulletObject, scetObject, true);
        Physics2D.IgnoreLayerCollision(starObject, scetObject, true);
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
