using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameStateControl", menuName = "Game State/GameStateControl")]
public class SOGameStateControl : ScriptableObject
{
    [HideInInspector] public UnityEvent OnSceneLoad;
    [HideInInspector] public UnityEvent OnLevelStart;
    [HideInInspector] public UnityEvent OnGameRun;
    [HideInInspector] public UnityEvent OnGamePause;
    [HideInInspector] public UnityEvent OnLevelEnd;
    [HideInInspector] public UnityEvent OnSceneUnload;


    public void SetSceneLoad()
    {
        OnSceneLoad?.Invoke();
    }

    public void SetLevelStart()
    {
        OnLevelStart?.Invoke();
    }

    public void SetGameRun()
    {
        OnGameRun?.Invoke();
    }

    public void SetGamePause()
    {
        OnGamePause?.Invoke();
    }

    public void SetLevelEnd()
    {
        OnLevelEnd?.Invoke();
    }

    public void SetSceneUnload()
    {
        OnSceneUnload?.Invoke();
    }

}
