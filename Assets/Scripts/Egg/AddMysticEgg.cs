using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMysticEgg : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if (MysticEggBox.life < 2)
        {
            MysticEggBox.mysticEgg++;
            PlayerPrefs.SetInt("mysticEgg", MysticEggBox.mysticEgg); // сохраняем значение в PlayerPrefs
            PlayerPrefs.Save();
        }
    }


    public void Break()
    {

        Destroy(gameObject);
    }
}
