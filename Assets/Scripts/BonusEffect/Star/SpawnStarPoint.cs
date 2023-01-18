using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStarPoint : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointPivot;
    [SerializeField] private Staring _staringTemplate;



    public void BuildStar()
    {
        for (int i = 0; i < 1; i++)
        {
            Staring spawnedStaring = _staringTemplate;
            Staring newStaring = Instantiate(spawnedStaring);
            newStaring.SetTargetTransform(_spawnPointPivot);
            //newStaring.transform.position = _spawnPointPivot.position;

        }
        

    }

    public void Break()
    {
        Destroy(gameObject);
    }


}
