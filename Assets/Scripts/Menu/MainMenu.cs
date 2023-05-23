using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static int  money;
    public static int animal;
    public int earnedMoney;
    public Text moneyText;
    public TextMeshProUGUI animalText;
    private void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        earnedMoney = PlayerPrefs.GetInt("Score");
        money += earnedMoney;
        PlayerPrefs.SetInt("Money", money);
        moneyText.text = money.ToString();
        earnedMoney = 0;
        PlayerPrefs.SetInt("Score", earnedMoney);
        animal = PlayerPrefs.GetInt("Animal");
        animalText.text = animal.ToString();
    }




    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }
}
