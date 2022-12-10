using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("General")]
    //[SerializeField] private Transform _container;
    [SerializeField] float _maxTime;
    [SerializeField] private GameObject[] _obstacleTemplates;
    [SerializeField] float _height;
    [Header("Tower")]
    [SerializeField] private GameObject _blockTemplate;
    [SerializeField] private int _blockSpawnChance;
    //[SerializeField]
    //private GameObject _blockSpawnPoint;
 //  private SpawnPoint[] _blockSpawnPoint; //2
    private float timer = 0;

    void Start()
    {

      // _blockSpawnPoint = GetComponentsInChildren<GameObject>();
       // _blockSpawnPoints = GetComponentsInChildren<SpawnPoint>();
        // GameObject spawnedObstacle = _obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)];

        //GameObject newpipe = Instantiate(spawnedObstacle);
        //newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);

      


    }


    void Update()
    {
        if (timer >_maxTime)
        {
         //   _blockSpawnPoint = GetComponentsInChildren<SpawnPoint>(); //2
            GenerateRandomTower( _obstacleTemplates,  _height);
         //   GenerateRandomElements( _blockSpawnPoint, _blockTemplate.gameObject, _blockSpawnChance);
        }
        timer += Time.deltaTime;
    }

    private void GenerateRandomTower(GameObject[] _obstacleTemplates,float _height)
    {
        GameObject spawnedObstacle = _obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)];
        GameObject newpipe = Instantiate(spawnedObstacle);

        newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);
        Destroy(newpipe, 15);
        timer = 0;
    }

    //private void GenerateRandomElements(SpawnPoint[] spawnPoint, GameObject generatedElement, int spawnChance)
    //{
    //    if (Random.Range(0, 100) < spawnChance)
    //    {
    //        GameObject element = GenerateElement(spawnPoint[0].transform.position, generatedElement);

    //        element.transform.position = transform.position;
    //        Destroy(element, 15);
    //        timer = 0;

    //    }


    //}


    //private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement)
    //{
    //    // spawnPoint.y -= generatedElement.transform.localScale.y;
    //    return Instantiate(generatedElement, spawnPoint, Quaternion.identity);

    //}






}

    


