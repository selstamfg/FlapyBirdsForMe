using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonusLife : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LifeBox.life<2) 
        {
            LifeBox.life++;
            //PlayerPrefs.SetInt("life", LifeBox.life); // сохраняем значение в PlayerPrefs
           // PlayerPrefs.Save();
        }
    }



    public void Break()
    {

        Destroy(gameObject);
    }
}
