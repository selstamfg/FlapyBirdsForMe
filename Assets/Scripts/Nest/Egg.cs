using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float incubationTime = 10f; // ����� ���������
    private bool isHatched = false; // ����, ������������, ���������� �� ����
    private bool isBeingDragged = false; // ����, ������������, ��������������� �� ���� � ������ ������
    private Vector2 startPosition; // ��������� ������� ����
    private float timeLeft; // ���������� ����� ���������
    private Collider2D eggCollider; // ��������� ����
    private Nest currentNest; // ������� ������

    void Start()
    {
        startPosition = transform.position;
        eggCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isHatched)
        {
            // ���� ���� ����������, ������� ��� �� ������ �� ����� � ����������� �
            currentNest.RemoveEgg();
            Destroy(gameObject);
        }
        else if (timeLeft > 0)
        {
            // ���� ���� ��� �� ���������� � �������� ����� ���������,
            // ��������� ���������� ����� �� ������ �����
            timeLeft -= Time.deltaTime;
        }
        else
        {
            // ����� ���� ����������
            isHatched = true;
            eggCollider.enabled = false; // ��������� ���������, ����� ���� ������ �� ����� ������������ � ������� ���������
            transform.GetChild(0).gameObject.SetActive(true); // �������� ������ ������������� ������
        }
    }

    void OnMouseDown()
    {
        if (!isHatched)
        {
            // ���������� ������� ������
            currentNest = transform.parent.GetComponent<Nest>();
            // ���������� ��������� ������� ���� � ���������� ���� ��������������
            startPosition = transform.position;
            isBeingDragged = true;
            // ������� ���� �� ������
            currentNest.RemoveEgg();
        }
    }

    void OnMouseUp()
    {
        if (!isHatched && isBeingDragged)
        {
            // ���������� ���� �������������� � false
            isBeingDragged = false;
            // ���� ��������� ������
            GameObject[] nests = GameObject.FindGameObjectsWithTag("Nest");
            Nest nearestNest = null;
            float nearestDistance = Mathf.Infinity;
            foreach (GameObject nest in nests)
            {
                Nest nestScript = nest.GetComponent<Nest>();
                float distance = Vector2.Distance(transform.position, nest.transform.position);
                if (distance < nearestDistance && nestScript.HasSpace())
                {
                    nearestNest = nestScript;
                    nearestDistance = distance;
                }
            }
            if (nearestNest != null)
            {
                // ���� ����� ��������� ������, ���������� ���� � ����
                transform.position = nearestNest.GetFreeCellPosition();
                // �������� ���� � ������ � ���������� ������� ������ � null
                nearestNest.PlaceEgg(this);
                currentNest = null;
            }
            else
            {
                // ���� ���������� ������ �� �����, ���������� ���� �� ��������� �������
                transform.position = startPosition;
                // ���������� ���� � ������, ������ ��� ���� �����
                currentNest.PlaceEgg(this);
                currentNest = null;
            }
        }
    }
}

