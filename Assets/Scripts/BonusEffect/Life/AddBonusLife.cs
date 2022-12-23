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

        }
    }



    public void Break()
    {

        Destroy(gameObject);
    }
}
