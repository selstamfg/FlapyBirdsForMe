using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClaimBonusUpPanel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI messageBonusUp;
    [SerializeField] private Button increaseBonusBtn;
    [SerializeField] private Button closeBtn;
    [SerializeField] private CanvasGroup cg;
    [SerializeField] private int minCoin;

    private int currentSkillIndex = -1;
    public static ClaimBonusUpPanel Instance;
    public int _skillKofNum;
    private int _valueAnimal;
    private int _valueCoins;



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }


    public void Show()
    {
        if (PlayerPrefs.GetInt("Animal" ) >= 1 || PlayerPrefs.GetInt("Money")>=minCoin )
        {
            messageBonusUp.text = $" You want to increase the skill level by +1";// BonusUpText;
        }
        else if(PlayerPrefs.GetInt("Animal") <= 1 || PlayerPrefs.GetInt("Money") <= minCoin)
        {
            messageBonusUp.text = $" You don't have enough resources to level up your skill";// BonusUpText;
        }
        else if (_skillKofNum == 10)
        {
            messageBonusUp.text = $" You have reached the maximum skill level";
        }
       
        gameObject.LeanScale(Vector2.one, .5f).setEaseOutBack();
        cg.blocksRaycasts = true;
        //gameObject.SetActive(true);

    }
    
    public void Hide()
    {
        //gameObject.SetActive(false);
        cg.blocksRaycasts = false;
        gameObject.LeanScale(Vector2.zero, .5f).setEaseInBack();
    }

    public void IncreaseBonus()
    {
        if ( PlayerPrefs.GetInt("Animal") >= 1)
        {
            currentSkillIndex = PlayerPrefs.GetInt("skillNum");
            PlayerPrefs.SetInt("skillKofNum" + currentSkillIndex, _skillKofNum++);
            PlayerPrefs.SetInt("Animal", _valueAnimal-1);
        }
        else if(PlayerPrefs.GetInt("Money") >= minCoin)
        {
            currentSkillIndex = PlayerPrefs.GetInt("skillNum");
            PlayerPrefs.SetInt("skillKofNum" + currentSkillIndex, _skillKofNum++);
            PlayerPrefs.SetInt("Money", _valueCoins - minCoin);
        }
        else
        {
           // currentSkillIndex = PlayerPrefs.GetInt("skillNum");
           // PlayerPrefs.SetInt("skillKofNum" + currentSkillIndex, _skillKofNum);
        }
    }

    public void ClosePanel()
    {
        Hide();
    }

}
