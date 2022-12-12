using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Obstacle))]

public class ObstacleSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float _maxTime;
    [SerializeField] float _height;
    private Transform _currentPoint;
    [SerializeField] private Obstacle[] _obstacleTemplates;
    [Header("Box")]
    [SerializeField] private Box[] _boxTemplates;
    [SerializeField] int _spawnChance;


    //public Obstacle _buildPoint;
    // _buildPoint= GameObject.FindGameObjectsWithTag("Respawn");

    
    private float timer = 0;

    void Start()
    {
        
        //GameObject newpipe = Instantiate(spawnedObstacle);
        //newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);
        
    }


    void Update()
    {
        BuildTower();

    }


    private void BuildTower()
    {
        
       // _buildPoint = GetComponent<Obstacle>();
       // _currentPoint = _buildPoint.transform;
       // Obstacle currentPoint = _buildPoint.transform.position;

        if (timer > _maxTime)
        {

            // GenerateRandomObstacle( _obstacleTemplates,  _height);
            // GenerateRandomBox(_boxTemplates, _spawnChance,);
            GenerateRandomObstacle(_obstacleTemplates, _height, _boxTemplates, _spawnChance);


        }
        timer += Time.deltaTime;
            

    }


    public void GenerateRandomObstacle(Obstacle[] _obstacleTemplates, float _height, Box[] _boxTemplates, int _spawnChance)
    {
        Obstacle spawnedObstacle = _obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)];
        Obstacle newObstacle = Instantiate(spawnedObstacle);
      //  GetComponent();
        newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);
        Transform _currentPoint=newObstacle.SpawnPoint;
         
        if (Random.Range(0, 100) < _spawnChance)
        {
           
            Box spawnedBox = _boxTemplates[Random.Range(0, _boxTemplates.Length)];
            Box newBox = Instantiate(spawnedBox);

            newBox.transform.position = _currentPoint.position;//newObstacle.transform.position+ new Vector3(3, 1.5f, 0);

            Destroy(newBox, 15);
            timer = 0;
        }


        Destroy(newObstacle, 15);
        timer = 0;
    }



    //public void GenerateRandomObstacle(Obstacle[] _obstacleTemplates,float _height)
    //{
    //    Obstacle spawnedObstacle = _obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)];
    //    Obstacle newObstacle = Instantiate(spawnedObstacle);
    //    newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);
    //    //  currentSegment
    //   // _currentPoint.position = newObstacle.transform.position;

    //    Destroy(newObstacle, 15);
    //   timer = 0;
    //}



    //private void GenerateRandomBox(Box[] _boxTemplates, int _spawnChance,Obstacle newObstacle)
    //{
    //    if (Random.Range(0, 100) < _spawnChance)
    //    {
    //        //  Transform currentPoint = _buildPoint;

    //        Box spawnedBox = _boxTemplates[Random.Range(0, _boxTemplates.Length)];
    //        Box newBox = Instantiate(spawnedBox);
    //        //currentPoint = newBox.transform;
    //        newBox.transform.position = newObstacle.transform.position;//transform.position + new Vector3(0, Random.Range(-_height, _height), 0);

    //        Destroy(newBox, 15);
    //       timer = 0;
    //    }

    //}


    //private Vector3 GetBuildPoint(Transform currentPoint)
    //{
    //    return new Vector3(transform.position.x, currentPoint.position.y + currentPoint.localScale.y / 2, transform.position.z);
    //}


}




