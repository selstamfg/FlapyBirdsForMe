using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
   // public string sceneName; // ��� �����, � ������� ����� ��������� ������
    public float rotationSpeed = 1f; // �������� �������� ������� � �������� � �������
    public Transform portalImage; // ������ �� �������� ������ � ������������ �������
    public static Action onTouchedPortal;

    void Update()
    {
        
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // �������� ������� ������ ����� ���
        portalImage.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime); // �������� ����������� ������ ������� � �������� �������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Stolknovenia");
            onTouchedPortal?.Invoke();
           Destroy(gameObject);
            //  SceneManager.LoadScene(sceneName); // ��������� ����� �����
        }
    }

}
