using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonusBox : MonoBehaviour
{
    private int a = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BonusBox._bonus++; 
    }
}