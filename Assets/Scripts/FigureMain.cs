using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureMain : MonoBehaviour
{

    private BirdFly player;
    public Transform playerPos;
    public GameObject[] players;

    void Awake()
    {
        player = Instantiate(players[PlayerPrefs.GetInt("Player")], playerPos.position, Quaternion.identity).GetComponent<BirdFly>(); 
       // player = Instantiate(players[PlayerPrefs.GetInt("Player")]).GetComponent<BirdFly>();
    }
}
