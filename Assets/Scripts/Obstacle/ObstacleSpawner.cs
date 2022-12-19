using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Obstacle))]

public class ObstacleSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float _maxTime;
    [SerializeField] float _height;
    float _MaxTime;
    float koefSand = 2;
   
    [SerializeField] private Obstacle[] _obstacleTemplates;
    [Header("Box")]
    [SerializeField] private Box[] _boxTemplates;
    [SerializeField] int _spawnChanceBox;
    private Transform _currentPointBox;
    [Header("Bonus")]
    [SerializeField] private Bonus[] _bonusTemplates;
    [SerializeField] int _spawnChanceBonus;
    private Transform _currentPointBonus;
    [Header("Scet")]
    [SerializeField] private Scet _scetTemplates;
    private Transform _currentPointScet;


    bool speedNorm = true;

    private float timer = 0;

    void Start()
    {

    }


    void Update()
    {
        BuildTower();
        Speed(speedNorm);
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
            GenerateRandomObstacle(_obstacleTemplates, _height, _boxTemplates, _spawnChanceBox, _bonusTemplates, _spawnChanceBonus,_scetTemplates);

           // Destroy(Box)

        }
        timer += Time.deltaTime;
            
        
    }


    public void GenerateRandomObstacle(Obstacle[] _obstacleTemplates, float _height, Box[] _boxTemplates, int _spawnChanceBox, Bonus[] _bonusTemplates, int _spawnChanceBonus,Scet _scetTemplates)
    {

        Obstacle spawnedObstacle = _obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)];
         Obstacle newObstacle = Instantiate(spawnedObstacle);
        Destroy(newObstacle, 15);
        //public Obstacle desObs = newObstacle;
         //  GetComponent();
        newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);
        Transform _currentPointBox=newObstacle.SpawnPoint;
        Transform _currentPointBonus = newObstacle.SpawnPointBonus;
        Transform _currentPointScet = newObstacle.SpawnPointScet;


        if (Random.Range(0, 100) < _spawnChanceBox)
        {
           
            Box spawnedBox = _boxTemplates[Random.Range(0, _boxTemplates.Length)];
            Box newBox = Instantiate(spawnedBox);

            newBox.transform.position = _currentPointBox.position;

          
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


    private void OnEnable()
    {
        TimerSand.onSandTimer += BonusedSand;
    }
    private void OnDisable()
    {
        TimerSand.onSandTimer -= BonusedSand;
    }

    private void BonusedSand(bool bonusUp)
    {
        if (bonusUp == true)
        {

            _MaxTime= _maxTime*koefSand;
            speedNorm = false;

        }
    }


    private void Speed(bool speedNorm)
    {
        if (speedNorm == true)
        {

            _MaxTime = _maxTime;
            
        }
        speedNorm = true;

    }


}




