using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text _highScoreText;
   // [SerializeField] Text _scoreText;

    //public static int _score;
    int _highscore;
    void Start()
    {
       // _score = 0;
    }

    
    void Update()
    {
        _highscore = (int)Score.score;
      //  _scoreText.text = "" + _highscore.ToString();
        if (PlayerPrefs.GetInt("scorePipe") <= _highscore)
        {
            PlayerPrefs.SetInt("scorePipe",_highscore);
        }
        _highScoreText.text = "" + PlayerPrefs.GetInt("scorePipe").ToString();
    }
}
