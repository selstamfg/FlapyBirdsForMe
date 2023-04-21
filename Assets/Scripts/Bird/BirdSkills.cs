using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSkills : MonoBehaviour
{
    
    [SerializeField] private int _id;
    [Header("Еxtra chances for boxes")]//дополнительные шансы для спавна ящиков
    [SerializeField] private Vector2Int _chancesBox1;
    [SerializeField] private Vector2Int _chancesBox3;
    [SerializeField] private Vector2Int _chancesBox5;
    [SerializeField] private Vector2Int _chancesBox7;
    [Header("Еxtra chances for bonus")]//дополнительные шансы для спавна бонусов
    [SerializeField] private Vector2Int _chancesSand;
    [SerializeField] private Vector2Int _chancesSnow;
    [SerializeField] private Vector2Int _chancesGrow;
    [SerializeField] private Vector2Int _chancesLight;
    [SerializeField] private Vector2Int _chancesStar;
    [SerializeField] private Vector2Int _chancesSmall;
    [SerializeField] private Vector2Int _chancesEye;
    [SerializeField] private Vector2Int _chancesGost;
    [SerializeField] private Vector2Int _chancesLife;
    [SerializeField] private Vector2Int _chancesBullet;
    [Header("reduced time for bonuses")]//уменьшеное время для боусов
    [SerializeField] private float _timerShortSand;
    [SerializeField] private float _timerShortSnow;
    [SerializeField] private float _timerShortGrow;
    [SerializeField] private float _timerShortLight;
    [SerializeField] private float _timerShortStar;
    [SerializeField] private float _timerShortSmall;
    [SerializeField] private float _timerShortEye;
    [SerializeField] private float _timerShortGost;
    [SerializeField] private float _timerShortLife;
    [SerializeField] private float _timerShortBullet;



    public int GetId
    {
        get => _id;
    }

    public Vector2Int GetChances
    {
        get => _chancesBox1;
      //  get => _chancesBox3;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
