using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public static Action onTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AddBonusEye bonusEyeTime))
        {

                Debug.Log("Я ударился");
                onTouched?.Invoke();
        }
}
}
