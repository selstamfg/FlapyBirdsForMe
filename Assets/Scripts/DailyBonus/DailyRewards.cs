using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewards : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI status;
    //[SerializeField] private Text status;
    [SerializeField] private Button claimBtn;

    [Header("Prefab Settings")]
    [SerializeField] private RewardPref rewardPref;
    [SerializeField] private Transform rewardsGrid;

    [Header("Prefab Settings")]
    [SerializeField] private List<Reward> rewards;

    private List<RewardPref> rewardPrefabs;

    private int currentStreak
    {
        get => PlayerPrefs.GetInt("currentStreak", 0);
        set => PlayerPrefs.SetInt("currentStreak", value);
    }


   // private Date
    private DateTime? lastClaimTime
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimedTime", null);

            if (!string.IsNullOrEmpty(data))
            {
                return DateTime.Parse(data);
            }
            return null;
        }

        set
        {
            if (value != null)
            {
                PlayerPrefs.SetString("lastClaimedTime", value.ToString());
            }
            else
            {
                PlayerPrefs.DeleteKey("lastClaimedTime");
            }
        }
    }


    private bool canClaimReward;
    private int maxStreakCount = 7;
    private float claimCooldown = 24f / 24 / 60 / 6 / 2;
    private float claimDeadline = 48f / 24 / 60 / 6 / 2;

    private void Start()
    {
        InitPrefabs();
        StartCoroutine(RewardsStateUpdater());
    }

    private void InitPrefabs()
    {
        rewardPrefabs = new List<RewardPref>();

        for (int i = 0; i < maxStreakCount; i++)
        {
            rewardPrefabs.Add(Instantiate(rewardPref, rewardsGrid, false));
        }
    }
     private  IEnumerator RewardsStateUpdater()
     {
        while (true)
        {
            UpdateRewardsState();
            yield return new WaitForSeconds(1);
        }
     }

    private void UpdateRewardsState()
    {
       canClaimReward = true;
        if (lastClaimTime.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTime.Value;

            if (timeSpan.TotalHours>claimDeadline)
            {
                lastClaimTime = null;
                currentStreak = 0;
            }
            else if(timeSpan.TotalHours<claimCooldown)
            {
                canClaimReward = false;
            }
        }
        UpdateRewardsUI();
    }

    private void UpdateRewardsUI()
    {
        claimBtn.interactable = canClaimReward;

        if (canClaimReward)
        {
            status.text = "Claim your reward!";
        }
        else
        {
            var nextClaimTime = lastClaimTime.Value.AddHours(claimCooldown);
            var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

            status.text = $"Come back in {cd} for your next reward";
        }

        for (int i = 0; i < rewardPrefabs.Count; i++)
        {
            rewardPrefabs[i].SetRewardData(i, currentStreak, rewards[i]);
        }
    }

    public void ClaimReward()
    {
        if (!canClaimReward)
        {
            return;
        }

        var reward = rewards[currentStreak];
        switch (reward.Type)
        {
            case Reward.RewardType.COINS:
                GameControler.Instance.AddCoins(reward.Value);
                break;
            case Reward.RewardType.ANIMAL:
                GameControler.Instance.AddAnimal(reward.Value);
                break;
        }

        ClaimRewardPanel.Instance.Show(reward);

        lastClaimTime = DateTime.UtcNow;
        currentStreak = (currentStreak + 1) % maxStreakCount;

        UpdateRewardsState();
    }

}
