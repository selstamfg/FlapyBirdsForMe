using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
   // public string sceneName; // ��� �����, � ������� ����� ��������� ������
    public float rotationSpeed = 1f; // �������� �������� ������� � �������� � �������

    // Update ���������� ���� ��� �� ����
    void Update()
    {
        // �������� ������� ������ ����� ���
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          //  SceneManager.LoadScene(sceneName); // ��������� ����� �����
        }
    }
}
