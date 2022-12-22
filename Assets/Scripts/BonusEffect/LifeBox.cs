using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : MonoBehaviour
{
    public static int life=1;
    

    private void Start()
    {
        life = 1;
      //  LifeLevel();
    }



    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = life.ToString();
    }


    
   





}
