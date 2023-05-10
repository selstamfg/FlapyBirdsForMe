using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticEggBox : MonoBehaviour
{
    public static int mysticEgg = 0;

    private void Start()
    {
        // ������ ����������� �������� �� PlayerPrefs
        mysticEgg = PlayerPrefs.GetInt("mysticEgg", 0);
    }

    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = mysticEgg.ToString();
    }
}
