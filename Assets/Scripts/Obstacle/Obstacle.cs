using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    [SerializeField] private Transform _spawnPoint;

    public Transform SpawnPoint => _spawnPoint;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        
            Destroy(gameObject,15);
        
    }
}
