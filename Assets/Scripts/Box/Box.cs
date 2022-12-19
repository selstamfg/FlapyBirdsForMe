using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    [SerializeField] private float speed;
    bool speedNorm = true;
    private int _bonusSize;


    private void Start()
    {
       
    }


    void Update()
    {
       Speed(speedNorm);
        transform.position += Vector3.left * (speed ) * Time.deltaTime;
        Destroy(gameObject, 15);
    }

    public void Break()
    {
        

        // ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        // renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        TimerSand.onSandTimer += BonusedSnow;
    }
    private void OnDisable()
    {
        TimerSand.onSandTimer -= BonusedSnow;
    }

    private void BonusedSnow(bool bonusUp)
    {
        if (bonusUp == true)
        {
            speed= 0.5f;
            speedNorm = false;
        }
    }


    private void Speed(bool speedNorm)
    {
        if (speedNorm == true)
        {
            speed= 1f;
            //  Debug.Log("бонус Sand ne действует  на обстакле");
        }
        speedNorm = true;
    }
}
