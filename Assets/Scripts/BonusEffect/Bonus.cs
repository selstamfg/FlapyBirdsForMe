using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
     public float speed;
   // [SerializeField] GameManager _gameManager;
  //  [Header("Gost Bonus")]
  //  [SerializeField] private AddBonusGost _bonusGostTemplates;


    private void Start()
    {
       
    }


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(gameObject, 15);
    }

   

}
