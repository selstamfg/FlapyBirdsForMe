using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Rewards : MonoBehaviour
{
    public float msToWait = 5000.0f;
    private Text Timer;
    private Button RewardButton;
    private ulong lastOpen;

    
    private void Start()
    {
        RewardButton = GetComponent<Button>();
        lastOpen = ulong.Parse(PlayerPrefs.GetString("lastOpen"));
        Timer = GetComponentInChildren<Text>();

        if (!isReady())
        {
            RewardButton.interactable = true;
            
        }
    }

    private void Update()
    {
        if (!RewardButton.IsInteractable())
        {
            if (isReady())
            {
                RewardButton.interactable = true;
                Timer.text = "ne gotovo!";
                return;
            }
                ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
                ulong m = diff / TimeSpan.TicksPerMillisecond;
                float secondleft = (float)(msToWait - m) / 1000.0f;

                string t = "";

                t += ((int)secondleft / 3600).ToString() + "÷";
                secondleft -= ((int)secondleft / 3600) * 3600;
                t += ((int)secondleft / 60).ToString("00") + "ì";
                t += ((int)secondleft % 60).ToString("00") + "c";
            
        }
    }
    
    public void Click()
    {
        lastOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        RewardButton.interactable = false;
    }


    private bool isReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float seconleft = (float)(msToWait - m) / 1000.0f;
        if (seconleft<0)
        {
            Timer.text = "gotovo!";
            return true;
        }
        return false;
    }
}
