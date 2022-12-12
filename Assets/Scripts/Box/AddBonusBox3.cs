using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonusBox3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
          BonusBox._bonus3++;
    }
}
