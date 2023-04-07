using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private float speed=1f;
    private float Speed;
    float koefSand = 0.5f;
    float koefLight = 2f;
    

    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;

        BonusedSandiLight();
        Destroy(gameObject, 15);
    }

    private void BonusedSandiLight()
    {
        if (PlayerPrefs.GetInt("BonusSand") == 1)
        {
            Speed = speed * koefSand;
        }
        else if ((PlayerPrefs.GetInt("BonusLight") == 1))
        {
            Debug.Log("LightBonus");
            Speed = speed * koefLight;
        }
        else
        {
            Speed = speed;
        }
    }

    //private void BonusedLight()
    //{
    //    if (PlayerPrefs.GetInt("BonusLight") == 0)
    //    {
    //        Speed = speed;
    //    }
    //    else
    //    {
    //        Speed = speed * koefLight;
    //    }
    //}
}
