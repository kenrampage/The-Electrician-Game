using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateHelper : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] private SOGameStateHelper _soGameStateHelper;

    [Header("Events")]
    [SerializeField] private UnityEvent OnSceneLoad;
    [SerializeField] private UnityEvent OnLevelStart;
    [SerializeField] private UnityEvent OnGameRun;
    [SerializeField] private UnityEvent OnGamePause;
    [SerializeField] private UnityEvent OnLevelEnd;
    [SerializeField] private UnityEvent OnSceneUnload;

    private void Awake()
    {
        RegisterEventListeners();
    }

    private void RegisterEventListeners()
    {
        _soGameStateHelper.OnSceneLoad.AddListener(SetSceneLoad);
        _soGameStateHelper.OnLevelStart.AddListener(SetLevelStart);
        _soGameStateHelper.OnGameRun.AddListener(SetGameRun);
        _soGameStateHelper.OnGamePause.AddListener(SetGamePause);
        _soGameStateHelper.OnLevelEnd.AddListener(SetLevelEnd);
        _soGameStateHelper.OnSceneUnload.AddListener(SetSceneUnload);
    }

    private void SetSceneLoad()
    {
        OnSceneLoad?.Invoke();
    }

    private void SetLevelStart()
    {
        OnLevelStart?.Invoke();
    }

    private void SetGameRun()
    {
        OnGameRun?.Invoke();
    }

    private void SetGamePause()
    {
        OnGamePause?.Invoke();
    }

    private void SetLevelEnd()
    {
        OnLevelEnd?.Invoke();
    }

    private void SetSceneUnload()
    {
        OnSceneUnload?.Invoke();
    }

}
