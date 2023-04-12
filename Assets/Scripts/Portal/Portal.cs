using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
   // public string sceneName; // имя сцены, в которую нужно перенести игрока
    public float rotationSpeed = 1f; // скорость вращения портала в градусах в секунду
    public Transform portalImage; // ссылка на дочерний объект с изображением портала
    public static Action onTouchedPortal;

    void Update()
    {
        
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // вращение портала вокруг своей оси
        portalImage.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime); // вращение изображения внутри портала в обратную сторону
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Stolknovenia");
            onTouchedPortal?.Invoke();
           Destroy(gameObject);
            //  SceneManager.LoadScene(sceneName); // загрузить новую сцену
        }
    }

}
