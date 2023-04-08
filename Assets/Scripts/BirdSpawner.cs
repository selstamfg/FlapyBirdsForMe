using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    //public GameObject[] objectPrefabs; // массив префабов объектов для выбора
    //public Transform spawnPosition; // позиция для спавна объекта
    //private GameObject spawnedObject; // ссылка на спавнутый объект
    //private int currentPrefabIndex; // текущий индекс выбранного префаба

    //void Start()
    //{
    //    // получаем сохраненное значение индекса префаба из PlayerPrefs
    //    currentPrefabIndex = PlayerPrefs.GetInt("SkinNum");

    //    // создаем объект на позиции спавна и сохраняем ссылку на него
    //    spawnedObject = Instantiate(objectPrefabs[currentPrefabIndex], spawnPosition.position, Quaternion.identity);
    //}

    //void Update()
    //{
    //    // проверяем, изменилось ли выбранное положение в списке objectPrefabs с прошлого кадра
    //    int newPrefabIndex = PlayerPrefs.GetInt("SkinNum", currentPrefabIndex);
    //    if (newPrefabIndex != currentPrefabIndex)
    //    {
    //        // уничтожаем текущий объект и создаем новый на основе обновленного значения ObjectNum
    //        Destroy(spawnedObject);
    //        currentPrefabIndex = newPrefabIndex;
    //        spawnedObject = Instantiate(objectPrefabs[currentPrefabIndex], spawnPosition.position, Quaternion.identity);

    //        // сохраняем новое значение индекса префаба в PlayerPrefs
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
