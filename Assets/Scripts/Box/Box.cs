using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    [SerializeField] private float speed;
    bool speedNorm = true;
    private int _bonusSize;

    int bulletObject, boxObject;

    private void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        boxObject = LayerMask.NameToLayer("Box");
    }


    void Update()
    {
        Speed();
        transform.position += Vector3.left * (speed ) * Time.deltaTime;
        Destroy(gameObject, 15);

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
        TimerSand.onSandTimer += BonusedSnow;
    }
    private void OnDisable()
    {
        TimerSand.onSandTimer -= BonusedSnow;
    }

    private void BonusedSnow(bool bonusUp)
    {
        if (bonusUp)
        {
            speed= 0.5f;
            speedNorm = false;
        }
        speedNorm = true;
    }


    private void Speed()
    {
        if (this.speedNorm)
        {
            speed= 1f;
           speedNorm = true; //  Debug.Log("бонус Sand ne действует  на обстакле");
        }
    }
}
