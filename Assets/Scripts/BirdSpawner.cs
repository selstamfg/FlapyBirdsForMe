using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    //public GameObject[] objectPrefabs; // ������ �������� �������� ��� ������
    //public Transform spawnPosition; // ������� ��� ������ �������
    //private GameObject spawnedObject; // ������ �� ��������� ������
    //private int currentPrefabIndex; // ������� ������ ���������� �������

    //void Start()
    //{
    //    // �������� ����������� �������� ������� ������� �� PlayerPrefs
    //    currentPrefabIndex = PlayerPrefs.GetInt("SkinNum");

    //    // ������� ������ �� ������� ������ � ��������� ������ �� ����
    //    spawnedObject = Instantiate(objectPrefabs[currentPrefabIndex], spawnPosition.position, Quaternion.identity);
    //}

    //void Update()
    //{
    //    // ���������, ���������� �� ��������� ��������� � ������ objectPrefabs � �������� �����
    //    int newPrefabIndex = PlayerPrefs.GetInt("SkinNum", currentPrefabIndex);
    //    if (newPrefabIndex != currentPrefabIndex)
    //    {
    //        // ���������� ������� ������ � ������� ����� �� ������ ������������ �������� ObjectNum
    //        Destroy(spawnedObject);
    //        currentPrefabIndex = newPrefabIndex;
    //        spawnedObject = Instantiate(objectPrefabs[currentPrefabIndex], spawnPosition.position, Quaternion.identity);

    //        // ��������� ����� �������� ������� ������� � PlayerPrefs
    //        PlayerPrefs.SetInt("SkinNum", currentPrefabIndex);
    //        PlayerPrefs.Save();
    //    }
    //}
    public GameObject[] objects;
    public Transform spawnPosition;

    private GameObject playerObject;
    private int currentObjectIndex = -1;
  //  [SerializeField] float _normaling;
    void Start()
    {
        currentObjectIndex = PlayerPrefs.GetInt("skinNum");
        SpawnCurrentObject();
    }

    void Update()
    {
        int newObjectIndex = PlayerPrefs.GetInt("skinNum");
        if (newObjectIndex != currentObjectIndex)
        {
            Destroy(playerObject);
            currentObjectIndex = newObjectIndex;
            SpawnCurrentObject();
        }
    }

    void SpawnCurrentObject()
    {
        playerObject = Instantiate(objects[currentObjectIndex], spawnPosition.position, Quaternion.identity);
      //  playerObject.transform.localScale = new Vector3(_normaling, _normaling, _normaling);
    }
}
