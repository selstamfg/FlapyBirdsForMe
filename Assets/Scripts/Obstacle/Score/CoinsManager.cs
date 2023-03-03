using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] Text _highScoreText;
   
    int _highscore;
   

    void Update()
    {
        //_highscore = (int)CoinBox._sum;

        //if (PlayerPrefs.GetInt("scoreC") <= _highscore)
        //{
        //    PlayerPrefs.SetInt("scoreC", _highscore);
        //}
        if (GameManager.replay)
        {
            _highscore = CoinBox._sum;
            PlayerPrefs.SetInt("scoreC", _highscore);
        }
         
        

        //record
        //   if (PlayerPrefs.GetInt("scoreC") <= _highscore)
        //  {
        //       PlayerPrefs.SetInt("scoreC", _highscore);
        //  }


        _highScoreText.text = "" + PlayerPrefs.GetInt("scoreC").ToString();
    }
}
