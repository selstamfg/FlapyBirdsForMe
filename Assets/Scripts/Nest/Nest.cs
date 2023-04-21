using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    public int width = 3; // ������ ������
    public int height = 3; // ������ ������
    public float cellSize = 1f; // ������ ������
    public GameObject eggPrefab; // ������ ����
    private GameObject[,] cells; // ������ ������
    private List<GameObject> eggs; // ������ ���

    void Start()
    {
        // ������� ������ ������
        cells = new GameObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject cell = new GameObject();
                cell.transform.parent = transform;
                cell.transform.localPosition = new Vector3(x * cellSize, y * cellSize, 0f);
                cells[x, y] = cell;
            }
        }

        eggs = new List<GameObject>();
    }

    public bool HasSpace()
    {
        // ���������, ���� �� ��������� ����� � ������
        return eggs.Count < width * height;
    }

    public void PlaceEgg(Egg egg)
    {
        // ��������� ���� � ������ � �������� ��� � ������ ��������� ������
        eggs.Add(egg.gameObject);
        int index = eggs.Count - 1;
        int x = index % width;
        int y = index / width;
        egg.transform.position = cells[x, y].transform.position;
        egg.transform.parent = cells[x, y].transform;
    }

    public void RemoveEgg()
    {
        // ������� ��������� ���� �� ������
        if (eggs.Count > 0)
        {
            GameObject egg = eggs[eggs.Count - 1];
            eggs.RemoveAt(eggs.Count - 1);
            Destroy(egg);
        }
    }

    public Vector2 GetFreeCellPosition()
    {
        // ���� ������ ��������� ������ � ���������� � �������
        foreach (GameObject cell in cells)
        {
            if (cell.transform.childCount == 0)
            {
                return cell.transform.position;
            }
        }
        return Vector2.zero;
    }
}
