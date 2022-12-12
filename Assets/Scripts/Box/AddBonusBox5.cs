using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonusBox5 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BonusBox._bonus5++;
    }
}
