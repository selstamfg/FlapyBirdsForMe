using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scet : MonoBehaviour
{
    public float speed;

    int bulletObject,starObject, scetObject;


    private void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        starObject = LayerMask.NameToLayer("Star");
        scetObject = LayerMask.NameToLayer("Scet");
    }


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(gameObject, 15);

        Physics2D.IgnoreLayerCollision(bulletObject, scetObject, true);
        Physics2D.IgnoreLayerCollision(starObject, scetObject, true);
    }
}
