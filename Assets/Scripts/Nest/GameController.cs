using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject eggPrefab; // ������ ����
    public float spawnInterval = 5f; // �������� ����� ���������� ���
    public float spawnRange = 5f; // ������, � ������� ����� ���������� ����

    private float timeSinceLastSpawn; // �����, ��������� � ���������� ��������� ����

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
        // �������� ��������� ����� � �������� ������� �� ������ �����
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnRange;
        // ������� ���� �� ������� � ��������� �� ��������� �������
        GameObject egg = Instantiate(eggPrefab, spawnPosition, Quaternion.identity);
        // ������������� ������������ ������ ����
        egg.transform.SetParent(transform);
    }
}
