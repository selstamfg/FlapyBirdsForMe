using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
   // public string sceneName; // имя сцены, в которую нужно перенести игрока
    public float rotationSpeed = 1f; // скорость вращения портала в градусах в секунду

    // Update вызывается один раз за кадр
    void Update()
    {
        // Вращение портала вокруг своей оси
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          //  SceneManager.LoadScene(sceneName); // загрузить новую сцену
        }
    }
}
