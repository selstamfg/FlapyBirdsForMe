using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _maxTime;
    [SerializeField] float _height;
    // Start is called before the first frame update
    [SerializeField] private Obstacle _segmentTemplate;
    [SerializeField] private Box _blockTemplate;
   // [SerializeField] private Finish _finishTemplate;
    [SerializeField] private int _towerSize;

    private float timer = 0;


    private void Start()
    {
       BuildTower();
    }

    private void Update()
    {
        if (timer > _maxTime)
        {
            BuildTower();

        }
        timer += Time.deltaTime;
    }

    private void BuildTower()
    {

        GameObject currentPoint = gameObject;
        for (int i = 0; i < _towerSize; i++)
        {
            currentPoint = BuildSegment(currentPoint, _segmentTemplate.gameObject);
            currentPoint = BuildSegment(currentPoint, _blockTemplate.gameObject);
        }

      //  Destroy(BuildSegment, 15);
      //  timer = 0;

       // GenerateRandomTower(GameObject[] _obstacleTemplates, float _height)
        
       //     GameObject spawnedObstacle = _obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)];
          //GameObject newObstacle = Instantiate(spawnedObstacle);
           

         //   newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height), 0);

           


    }

    private GameObject BuildSegment(GameObject currentSegment, GameObject nextSegment)
    {
        return Instantiate(nextSegment, GetBuildPoint(currentSegment.transform, nextSegment.transform), Quaternion.identity, transform);

    }


    private Vector3 GetBuildPoint(Transform currentSegment, Transform nextSegment)
    {
        return new Vector3(transform.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + nextSegment.localScale.y / 2, transform.position.z);
    }

}
