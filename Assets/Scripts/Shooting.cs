using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweemShoots;
    private float _timeAfterShoot;

    private void Update()
    {
       // Shoot();
    }

    public void Shoot()
    { 
        _timeAfterShoot += Time.deltaTime;

            if (_timeAfterShoot > _delayBetweemShoots)
            {
                
                Bullet spawnedBullet = _bulletTemplate;
                Bullet newBullet = Instantiate(spawnedBullet);
                newBullet.transform.position = _shootPoint.position;


            _timeAfterShoot = 0;
            }
       
    }


}
