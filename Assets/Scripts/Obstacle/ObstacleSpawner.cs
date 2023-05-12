//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float _maxTime;
    [SerializeField] float _height;
    

    [SerializeField] private Obstacle[] _obstacleTemplates;
    [Header("Box")]
    [SerializeField] private Box[] _boxTemplates;
    [SerializeField] int _spawnChanceBox;
    private Transform _currentPointBox;
    [Header("Bonus")]
    [SerializeField] private Bonus[] _bonusTemplates;
   // [SerializeField] int _spawnChanceBonus;
    private Transform _currentPointBonus;
    [Header("Portal")]
    //[SerializeField] private Bonus[] _portalTemplates;
    [SerializeField] int _bonusIndex;
    [SerializeField] int _obstaclePassed;
    [Header("Scet")]
    [SerializeField] private Scet _scetTemplates;
    private Transform _currentPointScet;

    private float _MaxTime;
    private float koefSand = 2f;
    private float koefLight = 0.5f;
    private int _missCount;
    private bool speedNorm = true;
    private float timer = 0;
    private int _obstacleScore;
    private int _koefBox = 5;
    private int _koefBonus = 5;
    void Start()
    {
        BuildTower();
    }


    void Update()
    {
        _obstacleScore = (int)Score.score;
        BuildTower();
        BonusedSandiLight();
    }


    private void BuildTower()
    {
        if (timer > _MaxTime)
        {
            GenerateRandomObstacle(_obstacleTemplates, _height, _boxTemplates, _bonusTemplates, _scetTemplates);

        }
        timer += Time.deltaTime;
    }
    

    public void GenerateRandomObstacle(Obstacle[] _obstacleTemplates, float _height, Box[] _boxTemplates,  Bonus[] _bonusTemplates,  Scet _scetTemplates)
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

        int _spawnChanceBox = (Random.Range(0, 100));
        {
            foreach (var currentBox in _boxTemplates)
            {
                Vector2Int chances = currentBox.GetChances;

                if (_spawnChanceBox >= chances.x && _spawnChanceBox <= chances.y) 
                {
                    Box newBox = Instantiate(currentBox);
                    newBox.transform.position = _currentPointBox.position;
                }
            }
        }

        //if (Random.Range(0, 100) < _spawnChanceBonus)
        //{
        //    Bonus spawnedBonus = _bonusTemplates[Random.Range(0, _bonusTemplates.Length)];
        //    Bonus newBonus = Instantiate(spawnedBonus);
        //    newBonus.transform.position = _currentPointBonus.position;
        //}

        //if (Random.Range(0, 100) < _spawnChanceBonus)
        //{
        //    Bonus spawnedBonus = _bonusTemplates[Random.Range(0, _bonusTemplates.Length)];
        //    Bonus newBonus = Instantiate(spawnedBonus);
        //    newBonus.transform.position = _currentPointBonus.position;
        //}
        int _spawnChanceBonus = (Random.Range(0, 100));
        {
            foreach (var currentBonus in _bonusTemplates)
            {
                int currentSkillNum = PlayerPrefs.GetInt("skillNum");
                int bonusId = currentBonus.GetId;
                int currentSkillKof = PlayerPrefs.GetInt("skilKof" + bonusId);
                Vector2Int chances = currentBonus.GetChances;
                Vector2Int dopchances = currentBonus.DopChances;

                if (bonusId== currentSkillNum)
                {
                    currentBonus.DopChances = (new Vector2Int((int)(dopchances.x - _koefBonus * currentSkillKof), (int)(dopchances.y)));
                }
                else
                {
                    currentBonus.DopChances = (new Vector2Int((int)(dopchances.x), (int)(dopchances.y)));
                }
                

                if ((_spawnChanceBonus >= chances.x && _spawnChanceBonus <= chances.y) || (_spawnChanceBonus >= dopchances.x && _spawnChanceBonus <= dopchances.y))
                {

                    Bonus newBonus = Instantiate(currentBonus);
                    newBonus.transform.position = _currentPointBonus.position;
                }
            }
        }


        if (Random.Range(0, 100) < _spawnChanceBonus)
        {
            int currentBonusId = PlayerPrefs.GetInt("skillNum");
            int currentSkillKof = PlayerPrefs.GetInt("skilkofK" + currentBonusId);
            Bonus currentBonus = GetBonus(currentBonusId);
            Vector2Int chances = currentBonus.GetChances;
            Vector2Int dopchances = currentBonus.DopChances;

            currentBonus.DopChances = (new Vector2Int((int)(dopchances.x - _koefBonus * currentSkillKof), (int)(dopchances.y)));

            if ((_spawnChanceBonus >= chances.x && _spawnChanceBonus <= chances.y) || (_spawnChanceBonus >= dopchances.x && _spawnChanceBonus <= dopchances.y))
            {
                Bonus newBonus = Instantiate(currentBonus);
                newBonus.transform.position = _currentPointBonus.position;
            }

        }




        Scet spawnedScet = _scetTemplates;
        Scet newScet = Instantiate(spawnedScet);
        newScet.transform.position = _currentPointScet.position;

        timer = 0;
    }


    private Bonus GetBonus(int id)
    {
        for (int i = 0; i < _bonusTemplates.Length; i++)
        {
            if (_bonusTemplates[i].GetId==id)
            {
                return _bonusTemplates[i];
            }
        }

        return null;
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

   
}




