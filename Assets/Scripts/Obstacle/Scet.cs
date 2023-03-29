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
        BonusedSandiLight();
       // BonusedLight();
        Physics2D.IgnoreLayerCollision(bulletObject, scetObject, true);
        Physics2D.IgnoreLayerCollision(starObject, scetObject, true);
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
