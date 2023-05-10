using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg2 : MonoBehaviour
{
    [SerializeField] private EggType.Type _eggType;
    private bool _isTimerRunning = false;
    private Coroutine _timerCoroutine;

    public void SetType(EggType.Type type)
    {
        _eggType = type;
    }

    public void StartTimer(float timeInSeconds, EggType.Type eggType)
    {
        if (!_isTimerRunning)
        {
            _eggType = eggType;
            float time = GetTimeByEggType(eggType);
            _timerCoroutine = StartCoroutine(TimerCoroutine(time));
            _isTimerRunning = true;
        }
    }

    public void StopTimer()
    {
        if (_isTimerRunning)
        {
            StopCoroutine(_timerCoroutine);
            _isTimerRunning = false;
        }
    }

    private IEnumerator TimerCoroutine(float timeInSeconds)
    {
        float timeRemaining = timeInSeconds;

        while (timeRemaining > 0f)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }

        if (_eggType == EggType.Type.Normal || _eggType == EggType.Type.Rare || _eggType == EggType.Type.Legendary || _eggType == EggType.Type.Mythical || _eggType == EggType.Type.Mystical)
        {
            int randomKey = Random.Range(1, 4);
            int randomValue = PlayerPrefs.GetInt($"Key{randomKey}", 0);
            if (randomValue < 10)
            {
                PlayerPrefs.SetInt($"Key{randomKey}", randomValue + 1);
            }
        }

        _isTimerRunning = false;
    }

    private float GetTimeByEggType(EggType.Type eggType)
    {
        switch (eggType)
        {
            case EggType.Type.Normal:
                return 10f;
            case EggType.Type.Rare:
                return 20f;
            case EggType.Type.Legendary:
                return 30f;
            case EggType.Type.Mythical:
                return 40f;
            case EggType.Type.Mystical:
                return 50f;
            default:
                return 0f;
        }
    }
    //private void OnMouseDown()
    //{
       
    //    SetActiveEgg(this);
    //}
}
