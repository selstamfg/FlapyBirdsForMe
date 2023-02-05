using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartView : MonoBehaviour
{
    [SerializeField] private Transform _heartPoint;
    [SerializeField] private Heart _heartTemplate;
    private Transform _currentPointHeart;

    private void Start()
    {
        
    }


    private void Update()
    {
         Shoot();
    }

    public void Shoot()
    {
       

        if (LifeBox.life == 2)
        {

            Heart spawnedHeart = _heartTemplate;
             Heart newHeart = Instantiate(spawnedHeart);
            newHeart.transform.position = _heartPoint.position;

           // Box spawnedBox = _boxTemplates[Random.Range(0, _boxTemplates.Length)];
           // Box newBox = Instantiate(spawnedBox);

            //newBox.transform.position = _currentPointBox.position;



        }

       
    }




}
