using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillControled : MonoBehaviour
{
    public int skillNum;
    public Button buyButton;
    public Image iLock;
    public int price;

    public Sprite buySkill;
    public Sprite equipped;
    public Sprite equip;
    public Sprite falseLock;
    public Sprite trueLock;

    public Image[] skills;

    private void Start()
    {
        if (PlayerPrefs.GetInt("skill1" + "buy") == 0)
        {
            foreach (Image img in skills)
            {
                if ("skill1" == img.name)
                {
                    PlayerPrefs.SetInt("skill1" + "buy", 1);
                    PlayerPrefs.SetInt("skill1" + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);
                }
            }
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            iLock.GetComponent<Image>().sprite = falseLock;
            buyButton.GetComponent<Image>().sprite = buySkill;
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            iLock.GetComponent<Image>().sprite = trueLock;
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 1)
            {
                buyButton.GetComponent<Image>().sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
            {
                buyButton.GetComponent<Image>().sprite = equip;
            }
        }
    }
    public void buy()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (MainMenu.money >= price)
            {
                iLock.GetComponent<Image>().sprite = trueLock;
                buyButton.GetComponent<Image>().sprite = equipped;
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skillNum", skillNum);

                foreach (Image img in skills)
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
            PlayerPrefs.SetInt("skillNum", skillNum);

            foreach (Image img in skills)
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


    public void UpgradeSkill()
    {
        int currentLevel = PlayerPrefs.GetInt(GetComponent<Image>().name + "level", 1);
        int requiredItemAmount = 1; // Количество расходников, требующихся для улучшения скила

        // Проверяем, есть ли достаточно расходников для улучшения
        if (PlayerPrefs.GetInt("ItemAmount") >= requiredItemAmount)
        {
            // Уменьшаем количество расходников и увеличиваем уровень скила
            PlayerPrefs.SetInt("ItemAmount", PlayerPrefs.GetInt("ItemAmount") - requiredItemAmount);
            PlayerPrefs.SetInt(GetComponent<Image>().name + "level", currentLevel + 1);

            // Обновляем UI, чтобы отразить изменения
           // UpdateUI();
        }
        else
        {
            // Выводим сообщение о том, что у игрока недостаточно расходников для улучшения
            Debug.Log("Not enough items to upgrade skill.");
        }
    }

    //void UpdateUI()
    //{
    //    // Обновляем изображение уровня скила на основе текущего уровня
    //    int currentLevel = PlayerPrefs.GetInt(GetComponent<Image>().name + "level", 0);
    //    // ...
    //}




}

