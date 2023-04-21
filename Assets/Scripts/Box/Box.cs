using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int _id;
    [SerializeField] private Vector2Int _chances;
    [SerializeField] private Transform _spawnPointBreak;
    private float Speed;
    float koefSand = 0.5f;
    float koefLight = 2f;

     int bulletObject, boxObject;
  //  private int bulletObject = LayerMask.NameToLayer("Bullet");
   // private int boxObject = LayerMask.NameToLayer("Box");
    private UnityEngine.Object explosion;
  
    private Vector2Int _dop—hances = new Vector2Int(100, 100);

    //  int skinNum = PlayerPrefs.GetInt("skinNum");

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


    public Vector2Int GetDopChances
    {

        get => _dop—hances;
    }

    public void SetDopChances(Vector2Int newDopChances)
    {
        _dop—hances = newDopChances;
    }


    //public void UpdateDopChances(int skinNum)
    //{
    //    if (skinNum == 1)
    //    {
    //        _dopChances = new Vector2Int(80, 100);
    //    }
    //    else if (skinNum == 2)
    //    {
    //        _dopChances = new Vector2Int(85, 100);
    //    }
    //    else if (skinNum == 3)
    //    {
    //        _dopChances = new Vector2Int(90, 100);
    //    }
    //    else
    //    {
    //        _dopChances = new Vector2Int(95, 100);
    //    }
    //}

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
        //GameObject explosionRef = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
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
        int bonusSand = PlayerPrefs.GetInt("BonusSand");
        int bonusLight = PlayerPrefs.GetInt("BonusLight");

        if (bonusSand== 1)
        {
            Speed = speed * koefSand;
        }
        else if (bonusLight== 1)
        {
            Debug.Log("LightBox");
            Speed = speed * koefLight;
        }
        else
        {
            Speed = speed;
        }
    }





}
