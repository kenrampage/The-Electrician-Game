using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameStateHelper", menuName = "Game State/GameStateHelper")]
public class SOGameStateHelper : ScriptableObject
{
    [HideInInspector] public UnityEvent OnSceneLoad;
    [HideInInspector] public UnityEvent OnLevelStart;
    [HideInInspector] public UnityEvent OnGameRun;
    [HideInInspector] public UnityEvent OnGamePause;
    [HideInInspector] public UnityEvent OnLevelEnd;
    [HideInInspector] public UnityEvent OnSceneUnload;
}
