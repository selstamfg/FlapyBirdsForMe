using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : MonoBehaviour
{
    public static int life=1;
    

    private void Start()
    {
        life = 1;
        //  LifeLevel();
        // читаем сохраненное значение из PlayerPrefs
       // life = PlayerPrefs.GetInt("life", 1);
    }



    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = life.ToString();
    }

}
