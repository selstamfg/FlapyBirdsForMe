using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public Transform SpawnPoint => _spawnPoint;

    private void Update()
    {
        if (LifeBox.life != 2)
        {
            Break();
        }
    }




    public void Break()
    {
        Destroy(gameObject);
    }

}
