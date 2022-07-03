using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : Singleton<GameStateManager>
{
    public enum State
    {
        SCENELOADING,
        LEVELSTARTING,
        GAMERUNNING,
        GAMEPAUSED,
        LEVELENDING,
        SCENEUNLOADING
    }

    private State stateCurrent;
    private State statePrev;

    [SerializeField] private UnityEvent onSceneLoad;
    [SerializeField] private UnityEvent onLevelStart;
    [SerializeField] private UnityEvent onGameRun;
    [SerializeField] private UnityEvent onGamePause;
    [SerializeField] private UnityEvent onGameUnpause;
    [SerializeField] private UnityEvent onLevelEnd;
    [SerializeField] private UnityEvent onSceneUnload;

    public void SetState(State state)
    {
        if (state != stateCurrent)
        {
            statePrev = stateCurrent;
            stateCurrent = state;
            print("State changed from " + statePrev + " to " + stateCurrent);
            HandleStateChange();
        }
    }

    public State GetState()
    {
        return stateCurrent;
    }

    private void HandleStateChange()
    {
        switch (stateCurrent)
        {
            case State.SCENELOADING:
                onSceneLoad?.Invoke();
                break;

            case State.LEVELSTARTING:
                onLevelStart?.Invoke();
                break;

            case State.GAMERUNNING:
                if (statePrev == State.LEVELSTARTING)
                {
                    onGameRun?.Invoke();
                }
                else if (statePrev == State.GAMEPAUSED)
                {
                    onGameUnpause?.Invoke();
                }
                break;

            case State.GAMEPAUSED:
                onGamePause?.Invoke();
                break;

            case State.SCENEUNLOADING:
                onSceneUnload?.Invoke();
                break;

            default:
                break;
        }
    }
}
