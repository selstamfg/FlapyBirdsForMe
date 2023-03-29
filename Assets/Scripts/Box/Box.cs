using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    [SerializeField] private float speed=1f;
    [SerializeField] private int _id;
    [SerializeField] private Vector2Int _chances;
    [SerializeField] private Transform _spawnPointBreak;
    private float Speed;
    float koefSand = 0.5f;
    float koefLight = 2f;
    bool speedNorm = true;
    private int _bonusSize;

    int bulletObject, boxObject;
    private UnityEngine.Object explosion;

    private void Start()
    {
        explosion = Resources.Load("ExplosionBox");
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

    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        Destroy(gameObject, 15);
       // BonusedLight();
        BonusedSandiLight();
        Physics2D.IgnoreLayerCollision(bulletObject, boxObject, true);
    }
    public void Break()
    {
        // ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        // renderer.material.color = _meshRenderer.material.color;
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = _spawnPointBreak.position;
        Destroy(explosionRef, 1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  Debug.Log("OnTriggerEnter2D");

        if (collision.gameObject.tag == "Player")
        {
            Break();
        }
    }




            private void BonusedSandiLight()
    {
        if (PlayerPrefs.GetInt("BonusSand") == 1)
        {
            Speed = speed * koefSand;
        }
        else if ((PlayerPrefs.GetInt("BonusLight") == 1))
        {
            Speed = speed * koefLight;
        }
        else
        {
            Speed = speed;
        }
    }


}
