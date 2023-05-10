using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private float speed=1f;
    private float Speed;
    float koefSand = 0.5f;
    float koefLight = 2f;
    // private Vector2Int _dop—hances = new Vector2Int(100, 100);
    private Vector2Int _dop—hances;
    [SerializeField] private Vector2Int _chances;
    [SerializeField] private int _id;

    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;

        BonusedSandiLight();
        Destroy(gameObject, 15);
    }

    private void BonusedSandiLight()
    {
        int bonusSand = PlayerPrefs.GetInt("BonusSand");
        int bonusLight = PlayerPrefs.GetInt("BonusLight");

        if (bonusSand == 1)
        {
            Speed = speed * koefSand;
        }
        else if (bonusLight == 1)
        {
            Debug.Log("LightBox");
            Speed = speed * koefLight;
        }
        else
        {
            Speed = speed;
        }
    }

    //private void BonusedSkill()
    //{
    //    int skillNum = PlayerPrefs.GetInt("skillNum");
       

    //    if (skillNum == 11)
    //    {
    //        _dop—hances = new Vector2Int(100, 100);
    //    }
    //    else if (skillNum == 12)
    //    {
    //        Debug.Log("LightBox");
    //        Speed = speed * koefLight;
    //    }
    //    else
    //    {
    //        Speed = speed;
    //    }
    //}

   
    


    public Vector2Int GetChances
    {
        get => _chances;
    }

    public int GetId
    {
        get => _id;
    }

    public Vector2Int DopChances
    {

        get => _dop—hances;
        set
        {
            _dop—hances = value;
        }
    }

    //public void SetDopChances(Vector2Int newDopChances)
    //{
    //    _dop—hances = newDopChances;
    //}

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
