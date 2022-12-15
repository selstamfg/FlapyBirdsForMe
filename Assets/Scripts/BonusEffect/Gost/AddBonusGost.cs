using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonusGost : MonoBehaviour
{


    

    public void Gost()
    {

        //Physics2D.IgnoreCollision(_birdFly.GetComponent<Collider2D>(), _obstacle.GetComponent<Collider2D>());

       // _bird.Goster();
        Debug.Log("Effect");
    }

    //private void Gost()
    //{

    //   // BoxCollider2D bonuscolider = GetComponent<BoxCollider2D>();
    //    //bonuscolider.isTrigger = false;

    //}

    public void Break()
    {

        Destroy(gameObject);
    }

}
