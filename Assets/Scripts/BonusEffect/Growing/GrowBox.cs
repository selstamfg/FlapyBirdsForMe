using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowBox : MonoBehaviour
{
    public static int growi = 0;
    void Start()
    {
        growi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = growi.ToString();
    }
}
