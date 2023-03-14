using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static int money;
    public Text moneyText;

    // Update is called once per frame
    void Update()
    {
        money = PlayerPrefs.GetInt("Money");
        moneyText.text = money.ToString();
    }
}
