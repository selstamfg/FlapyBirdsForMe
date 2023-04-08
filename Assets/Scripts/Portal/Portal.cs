using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
   // public string sceneName; // ��� �����, � ������� ����� ��������� ������
    public float rotationSpeed = 1f; // �������� �������� ������� � �������� � �������
    public Transform portalImage; // ������ �� �������� ������ � ������������ �������

    void Update()
    {
        // �������� ������� ������ ����� ���
        // transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // �������� ������� ������ ����� ���
        portalImage.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime); // �������� ����������� ������ ������� � �������� �������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          //  SceneManager.LoadScene(sceneName); // ��������� ����� �����
        }
    }

}
