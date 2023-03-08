using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClaimRewardPanel : MonoBehaviour
{
    public static ClaimRewardPanel Instance;

    [SerializeField] private Image rewardIcon;
    [SerializeField] private TextMeshProUGUI rewardValue;
    [SerializeField] private CanvasGroup cg;

    [Header("Sprite")]
    [SerializeField] private Sprite rewardCoins;
    [SerializeField] private Sprite rewardAnimal;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    public void Show(Reward reward)
    {
        rewardIcon.sprite = reward.Type == Reward.RewardType.COINS ? rewardCoins : rewardAnimal;
        rewardValue.text = $"Got {reward.Value} {reward.Name}";

        gameObject.LeanScale(Vector2.one, .5f).setEaseOutBack();
        cg.blocksRaycasts = true;
    }

    public void Hide()
    {
        cg.blocksRaycasts = false;
        gameObject.LeanScale(Vector2.zero, .5f).setEaseInBack();
    }




}
