using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float speed;
   


    private void Start()
    {
       
    }


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(gameObject, 15);
    }

    public void Break()
    {

        Destroy(gameObject);
    }

}
