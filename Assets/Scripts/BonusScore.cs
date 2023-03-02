using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScore : MonoBehaviour
{
    public string _bonusName;
    public Text _bonusCount;

   // int coins = PlayerPrefs.GetInt("coins");
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (_bonusName)
        {
            //case "coin1":
            //    // int coins = PlayerPrefs.GetInt("coins");
            //    PlayerPrefs.SetInt("coins", coins + 1);
            //    _bonusCount.text = (coins + 1).ToString();
            //    Destroy(gameObject);
            //    break;

            //case "coin3":
            //    // int coins = PlayerPrefs.GetInt("coins");
            //    PlayerPrefs.SetInt("coins", coins + 3);
            //    _bonusCount.text = (coins + 3).ToString();
            //    Destroy(gameObject);
            //    break;

            case "coin5":
                    int coins = PlayerPrefs.GetInt("coins");
                PlayerPrefs.SetInt("coins", coins + 5);
                _bonusCount.text = (coins + 5).ToString();
                Destroy(gameObject);
                break;

            //case "coin7":
            //    // int coins = PlayerPrefs.GetInt("coins7");
            //    PlayerPrefs.SetInt("coins7", coins + 7);
            //    _bonusCount.text = (coins + 7).ToString();
            //    Destroy(gameObject);
            //    break;

                //case "pipes":
                //    int pipes = PlayerPrefs.GetInt("pipes");
                //    PlayerPrefs.SetInt("pipes", pipes + 1);
                //    _bonusCount.text = (pipes + 1).ToString();
                //   // Destroy(gameObject);
                //    break;
        }
   }
}
