using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public static GameControler Instance;

    public int Coins
    {
        get => PlayerPrefs.GetInt("Coins",0);
        private set => PlayerPrefs.SetInt("Coins", value);
    } 

    public int Animal 
    {
        get => PlayerPrefs.GetInt("Animal",0);
        private set => PlayerPrefs.SetInt("Animal", value);
    }
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI animalText;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int value)
    {
        Coins += value;
        UpdateUI();
    }
    
    public void AddAnimal(int value)
    {
        Animal += value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinsText.SetText(Coins.ToString("0"));
        animalText.SetText(Animal.ToString("0"));

    }
}
