using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerTest.onTouched += ConsoleMessage;
    }

    private void OnDisable()
    {
        PlayerTest.onTouched -= ConsoleMessage;
    }

    private void ConsoleMessage()
    {
        Debug.Log("ydar");
    }
}
