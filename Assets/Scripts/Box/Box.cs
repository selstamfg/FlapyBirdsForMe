using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    public float speed;
    public event UnityAction<Box> BirdHit;
    private int _bonusSize;






    private void Start()
    {
       // _bonusSize = 1;
        //  _view.text = _bonusSize.ToString();
    }


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(gameObject, 15);
    }

    public void Break()
    {
        //BirdHit?.Invoke(this);
       // Collect();

        // ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        // renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
    }

    //public int Collect()
    //{
    //    // Destroy(gameObject);
    //    return _bonusSize;
    //}
}
