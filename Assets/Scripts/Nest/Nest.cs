using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    public int width = 3; // ширина гнезда
    public int height = 3; // высота гнезда
    public float cellSize = 1f; // размер €чейки
    public GameObject eggPrefab; // префаб €йца
    private GameObject[,] cells; // €чейки гнезда
    private List<GameObject> eggs; // список €иц

    void Start()
    {
        // создаем €чейки гнезда
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
        // провер€ем, есть ли свободное место в гнезде
        return eggs.Count < width * height;
    }

    public void PlaceEgg(Egg egg)
    {
        // добавл€ем €йцо в список и помещаем его в первую свободную €чейку
        eggs.Add(egg.gameObject);
        int index = eggs.Count - 1;
        int x = index % width;
        int y = index / width;
        egg.transform.position = cells[x, y].transform.position;
        egg.transform.parent = cells[x, y].transform;
    }

    public void RemoveEgg()
    {
        // удал€ем последнее €йцо из списка
        if (eggs.Count > 0)
        {
            GameObject egg = eggs[eggs.Count - 1];
            eggs.RemoveAt(eggs.Count - 1);
            Destroy(egg);
        }
    }

    public Vector2 GetFreeCellPosition()
    {
        // ищем первую свободную €чейку и возвращаем еЄ позицию
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
