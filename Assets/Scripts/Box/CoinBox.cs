using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    private static int a3 = 3;
    private static int a5 = 5;
    private static int a7 = 7;
    public static int _bonus = 0;
    public static int _bonus3 = 0;
    public static int _bonus5 = 0;
    public static int _bonus7 = 0;
    private int _sum;

    private void Start()
    {
        _bonus = 0;
        _bonus3 = 0;
        _bonus5 = 0;
        _bonus7 = 0;
    }


    void Update()
    {
        _sum = _bonus + _bonus3*a3+_bonus5*a5+ _bonus7*a7;
        GetComponent<UnityEngine.UI.Text>().text = _sum.ToString();
    }
}
