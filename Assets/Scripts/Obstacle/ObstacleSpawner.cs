//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Obstacle))]

public class ObstacleSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float _maxTime;
    [SerializeField] float _height;
    

    [SerializeField] private Obstacle[] _obstacleTemplates;
    [Header("Box")]
    [SerializeField] private Box[] _boxTemplates;
    [SerializeField] int _spawnChanceBox;
    //[SerializeField] private int _spawnChanceBox1;
    //[SerializeField] private int _spawnChanceBox3;
    //[SerializeField] private int _spawnChanceBox5;
    //[SerializeField] private int _spawnChanceBox7;
    private Transform _currentPointBox;
    [Header("Bonus")]
    [SerializeField] private Bonus[] _bonusTemplates;
    [SerializeField] int _spawnChanceBonus;
    private Transform _currentPointBonus;
    [Header("Scet")]
    [SerializeField] private Scet _scetTemplates;
    private Transform _currentPointScet;

    //public Dictionary<int, int> _objectChance = new Dictionary<int, int> 
    //{
    //    { 0, 40 },
    //}
    private float _MaxTime;
    private float koefSand = 2f;
    private float koefLight = 0.5f;
    private int _missCount;
    private bool speedNorm = true;
    private float timer = 0;
    //private int chanceBox1=100- _spawnChanceBox1;
    //private int spawnChanceBox3;
    //private int spawnChanceBox5;
    //private int spawnChanceBox7;

    void Start()
    {
        BuildTower();
    }


    void Update()
    {
        BuildTower();
       // BonusedLight();
        BonusedSandiLight();
    }


    private void BuildTower()
    {

        // _buildPoint = GetComponent<Obstacle>();
        // _currentPoint = _buildPoint.transform;
        // Obstacle currentPoint = _buildPoint.transform.position;

        if (timer > _MaxTime)
        {

            // GenerateRandomObstacle( _obstacleTemplates,  _height);
            // GenerateRandomBox(_boxTemplates, _spawnChance,);
            //int chance = 50;
          //  int randomChance = Random.Range(0, 100);

            //if (chance >= randomChance)
            GenerateRandomObstacle(_obstacleTemplates, _height, _boxTemplates, _spawnChanceBox, _bonusTemplates, _spawnChanceBonus, _scetTemplates);

            // Destroy(Box)

        }
        timer += Time.deltaTime;


    }
    

    public void GenerateRandomObstacle(Obstacle[] _obstacleTemplates, float _height, Box[] _boxTemplates, int _spawnChanceBox, Bonus[] _bonusTemplates, int _spawnChanceBonus, Scet _scetTemplates)
    {
        Obstacle spawnedObstacle = _obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)];
        Obstacle newObstacle = Instantiate(spawnedObstacle);
        Destroy(newObstacle, 15);

        newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);
        Transform _currentPointBox = newObstacle.SpawnPoint;
        Transform _currentPointBonus = newObstacle.SpawnPointBonus;
        Transform _currentPointScet = newObstacle.SpawnPointScet;

        //if (Random.Range(0, 100) < _spawnChanceBox)
        //{

        //    Box spawnedBox = _boxTemplates[Random.Range(0, _boxTemplates.Length)];
        //    Box newBox = Instantiate(spawnedBox);

        //    newBox.transform.position = _currentPointBox.position;


        //}
        int spawnChanceBox = Random.Range(0, 100);

        for (int i = 0; i < _boxTemplates.Length; i++)
        {
            Vector2Int chances = _boxTemplates[i].GetChances;
              Box spawnedBox = _boxTemplates[i];

            if (spawnChanceBox >= chances.x && spawnChanceBox <= chances.y)
            {
                   Box newBox = Instantiate(spawnedBox);

                    newBox.transform.position = _currentPointBox.position;
            }
        }

        if (Random.Range(0, 100) < _spawnChanceBonus)
        {
            Bonus spawnedBonus = _bonusTemplates[Random.Range(0, _bonusTemplates.Length)];
            Bonus newBonus = Instantiate(spawnedBonus);

            newBonus.transform.position = _currentPointBonus.position;
        }
        Scet spawnedScet = _scetTemplates;
        Scet newScet = Instantiate(spawnedScet);
        newScet.transform.position = _currentPointScet.position;

        timer = 0;
    }


    private void BonusedSandiLight()
    {
        if (PlayerPrefs.GetInt("BonusSand") == 1)
        {
            _MaxTime = _maxTime * koefSand;
        }
        else if ((PlayerPrefs.GetInt("BonusLight") == 1))
        {
            _MaxTime = _maxTime * koefLight;
        }
        else
        {
            _MaxTime = _maxTime;
        }
    }

    //[Serializable]
    //public class BoxObjects
    //{
    //    public string id;
    //    public Box _box;
    //}
}




