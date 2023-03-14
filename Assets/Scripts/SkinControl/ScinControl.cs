using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScinControl : MonoBehaviour
{

    public int skinNum;
    public Button buyButton;
    public Image iLock;
    public int price;
    private int Money;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;
    public Sprite falseLock;
    public Sprite trueLock;

    public Image[] skins;

    public Text moneyText;

    private void Start()
    {
        Money = PlayerPrefs.GetInt("Money");

       // Debug.Log("Старт");

        if (PlayerPrefs.GetInt("scin1" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                if ("scin1" == img.name)
                {
                    PlayerPrefs.SetInt("scin1" + "buy", 1);
                    PlayerPrefs.SetInt("scin1" + "equip", 1);
                    Debug.Log("скин1");
                }
                else
                {
                    Debug.Log("скин_другой");
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);
                }
            }
        }
    }

    private void Update()
    {
        moneyText.text = skinNum.ToString();

        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            Debug.Log("скин не  куплен");
            iLock.GetComponent<Image>().sprite = falseLock;
            buyButton.GetComponent<Image>().sprite = buySkin;
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            Debug.Log("скин куплен");
            iLock.GetComponent<Image>().sprite = trueLock;
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 1)
            {
                Debug.Log("скин  вибрать ");
                buyButton.GetComponent<Image>().sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
            {
                Debug.Log("скин не выбран");
                buyButton.GetComponent<Image>().sprite = equip;
            }
        }
    }
    public void buy()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (Money >= price)
            {
                Debug.Log("денег достаточно");
                iLock.GetComponent<Image>().sprite = trueLock;
                buyButton.GetComponent<Image>().sprite = equipped;
                Money -= price;

                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);
                PlayerPrefs.SetInt("Coins", Money);

                foreach (Image img in skins)
                {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "equip", 0);
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            Debug.Log("скин куплен");
            iLock.GetComponent<Image>().sprite = trueLock;
            buyButton.GetComponent<Image>().sprite = equipped;
            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (Image img in skins)
            {
                if (GetComponent<Image>().name == img.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "equip", 0);
                }
            }
        }
    }



}
