using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SessionData", menuName = "Scriptable Objects/SessionData")]
public class SOSessionData : ScriptableObject, IResetSO
{
    [Header("Settings")]
    [SerializeField] private bool _splashScreenOn = true;

    public void Reset()
    {
        _splashScreenOn = true;
    }

    public bool GetSplashScreenStatus()
    {
        return _splashScreenOn;
    }

    public void TurnSplashScreenOff()
    {
        _splashScreenOn = false;
    }
}
