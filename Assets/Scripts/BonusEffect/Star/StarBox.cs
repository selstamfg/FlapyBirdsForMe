using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBox : MonoBehaviour
{
    public static int stari = 0;


    private void Start()
    {
        stari = 0;
        //  LifeLevel();
    }

    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = stari.ToString();
    }
}
