using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoinBox3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
          CoinBox._bonus3++;
    }
}
