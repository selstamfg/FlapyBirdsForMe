using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixComponentPosition : MonoBehaviour
{
 

    private SpriteRenderer spriteRenderer;
    private Vector2 initialPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
    }

    private void Update()
    {
       
        transform.position = initialPosition;
    }
}


