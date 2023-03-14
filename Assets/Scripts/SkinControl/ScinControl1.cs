using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScinControl1 : MonoBehaviour
{
    public int skinNum;
    public Button buyButton;
    public Image iLock;
    public int price;
    //private CoinText Coin;
    public int money;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;
    public Sprite falseLock;
    public Sprite trueLock;

    public Image[] skins;

    private void Start()
    {
        money = PlayerPrefs.GetInt("Money");

        if (PlayerPrefs.GetInt("scin1" + "buy1") == 0)
        {
            foreach (Image img in skins)
            {
                if ("scin1" == img.name)
                {
                    PlayerPrefs.SetInt("scin1" + "buy1", 1);
                    PlayerPrefs.SetInt("scin1" + "equip1", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy1", 0);
                }
            }
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy1") == 0)
        {
            iLock.GetComponent<Image>().sprite = falseLock;
            buyButton.GetComponent<Image>().sprite = buySkin;
        }
        else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy1") == 1)
        {
            iLock.GetComponent<Image>().sprite = trueLock;
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip1") == 1)
            {
                buyButton.GetComponent<Image>().sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip1") == 0)
            {
                buyButton.GetComponent<Image>().sprite = equip;
            }
        }
    }
    public void buy()
    {
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy1") == 0) {
            if (money >= price)
            {
                
                iLock.GetComponent<Image>().sprite = trueLock;
                buyButton.GetComponent<Image>().sprite = equipped;
                money -= price;
                
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy1", 1);
                PlayerPrefs.SetInt("skinNum1", skinNum);
                PlayerPrefs.SetInt("Coins", money);

                foreach(Image img in skins)
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
