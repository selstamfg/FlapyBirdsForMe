using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonusSandTime : MonoBehaviour
{
  //  public static Action<bool> onTouchedSand;


    //  float _speedFreez = 0.1f;
    // bool _sand = true;
    //   public bool _sandTimeOn = true;
    // string skor = "skor";
   // bool sandi = true;
    public void Break()
    {

        Destroy(gameObject);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    onTouchedSand?.Invoke(sandi);

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out BirdFly bird))
    //    {

    //        onTouchedSand?.Invoke(sandi);
    //    }


    //}
}