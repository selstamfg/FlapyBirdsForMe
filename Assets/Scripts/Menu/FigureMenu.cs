using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FigureMenu : MonoBehaviour
{
    public static int money;
    public static int animal;
    public int earnedMoney;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI animalText;
    public Text nameText;
    public Text descriptionText;
    private int currentObjectIndex = -1;
    private int currentSkillIndex = -1;
    private string[] skinNames = { "ѕтица 1", "ѕтица 2" };
    private string[] skillDescriptions= { "описание ѕтица 1", "описание ѕтица 2" };

    void Start()
    {
        currentSkillIndex = PlayerPrefs.GetInt("skillNum");
        currentObjectIndex = PlayerPrefs.GetInt("skinNum");
        NameCurrentObject();
        SkillCurrentObject();
        InfoCoin();
    }

    void Update()
    {
        int newObjectIndex = PlayerPrefs.GetInt("skinNum");
        int newSkillIndex = PlayerPrefs.GetInt("skillNum");

        if (newObjectIndex != currentObjectIndex)
        {
            currentObjectIndex = newObjectIndex;
            NameCurrentObject();
        }

        if (newObjectIndex != currentSkillIndex)
        {
            currentSkillIndex = newObjectIndex;
            SkillCurrentObject();
        }

    }

    void NameCurrentObject()
    {
        if (currentObjectIndex >= 0 && currentObjectIndex < skinNames.Length)
        {
            nameText.text = skinNames[currentObjectIndex];
        }
    }

    void SkillCurrentObject()
    {
        if (currentSkillIndex >= 0 && currentObjectIndex < skillDescriptions.Length)
        {
            descriptionText.text = skillDescriptions[currentSkillIndex];
        }
    }

    private void InfoCoin()
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

}
