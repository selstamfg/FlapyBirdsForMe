using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject eggPrefab; // префаб €йца
    public float spawnInterval = 5f; // интервал между по€влением €иц
    public float spawnRange = 5f; // радиус, в котором будут по€вл€тьс€ €йца

    private float timeSinceLastSpawn; // врем€, прошедшее с последнего по€влени€ €йца

    void Start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEgg();
            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnEgg()
    {
        // выбираем случайную точку в заданном радиусе от центра сцены
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnRange;
        // создаем €йцо из префаба и размещаем на выбранной позиции
        GameObject egg = Instantiate(eggPrefab, spawnPosition, Quaternion.identity);
        // устанавливаем родительский объект €йца
        egg.transform.SetParent(transform);
    }
}
