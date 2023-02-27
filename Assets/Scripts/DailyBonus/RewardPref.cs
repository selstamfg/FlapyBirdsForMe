using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardPref : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color currentStreakColor;

    [Header("Text Settings")]
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI rewardValue;

    [Header("View Settings")]
    [SerializeField] private Image rewardIcon;
    [SerializeField] private Sprite rewardCoins;
    [SerializeField] private Sprite rewardAnimal;

    public void SetRewardData(int day,int currentStreak, Reward reward)
    {
        dayText.text = $"Day {day + 1 }";

        rewardIcon.sprite = reward.Type == Reward.RewardType.COINS ? rewardCoins : rewardAnimal;
        rewardValue.text = reward.Value.ToString();

        background.color = day == currentStreak ? currentStreakColor : defaultColor;
    }
    
}
