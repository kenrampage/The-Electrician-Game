using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : Singleton<GameStateManager>
{
    public enum State
    {
        INIT,
        SCENELOADING,
        LEVELSTARTING,
        GAMERUNNING,
        GAMEPAUSED,
        LEVELENDING,
        SCENEUNLOADING
    }

    [SerializeField] private State stateCurrent;
    [SerializeField] private State statePrev;


    [NonReorderable]
    [SerializeField] private SerializedEvents[] onSceneLoadEvents;

    [NonReorderable]
    [SerializeField] private SerializedEvents[] onLevelStartEvents;

    [NonReorderable]
    [SerializeField] private SerializedEvents[] onGameRunEvents;

    [NonReorderable]
    [SerializeField] private SerializedEvents[] onGamePauseEvents;

    [NonReorderable]
    [SerializeField] private SerializedEvents[] onGameUnpauseEvents;

    [NonReorderable]
    [SerializeField] private SerializedEvents[] onLevelEndEvents;

    [NonReorderable]
    [SerializeField] private SerializedEvents[] onSceneUnloadEvents;

    // [SerializeField] private UnityEvent onSceneLoad;
    // [SerializeField] private UnityEvent onLevelStart;
    // [SerializeField] private UnityEvent onGameRun;
    // [SerializeField] private UnityEvent onGamePause;
    // [SerializeField] private UnityEvent onGameUnpause;
    // [SerializeField] private UnityEvent onLevelEnd;
    // [SerializeField] private UnityEvent onSceneUnload;

    public void StartCycleThroughEvents(SerializedEvents[] array)
    {
        StartCoroutine(CycleThroughEvents(array));
    }

    private IEnumerator CycleThroughEvents(SerializedEvents[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {

            if (i == array.Length - 1)
            {
                print("End of Events Array");
            }
            else
            {
                print("Waiting " + array[i].delay + " seconds before invoking event at index " + i);
            }

            yield return new WaitForSecondsRealtime(array[i].delay);

            array[i].InvokeEvent();

        }
    }

    private void OnEnable()
    {
        ResetStates();
        SetState(State.SCENELOADING);
    }

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
                // onSceneLoad?.Invoke();
                StartCycleThroughEvents(onSceneLoadEvents);
                break;

            case State.LEVELSTARTING:
                // onLevelStart?.Invoke();
                StartCycleThroughEvents(onLevelStartEvents);
                break;

            case State.GAMERUNNING:
                if (statePrev == State.LEVELSTARTING)
                {
                    // onGameRun?.Invoke();
                    StartCycleThroughEvents(onGameRunEvents);
                }
                else if (statePrev == State.GAMEPAUSED)
                {
                    // onGameUnpause?.Invoke();
                    StartCycleThroughEvents(onGameUnpauseEvents);
                }
                break;

            case State.GAMEPAUSED:
                // onGamePause?.Invoke();
                StartCycleThroughEvents(onGamePauseEvents);
                break;

            case State.SCENEUNLOADING:
                // onSceneUnload?.Invoke();
                StartCycleThroughEvents(onSceneUnloadEvents);
                break;

            default:
                break;
        }
    }

    private void ResetStates()
    {
        stateCurrent = State.INIT;
        statePrev = State.INIT;
    }

    public void SetSceneLoading()
    {
        SetState(State.SCENELOADING);
    }

    public void SetLevelStarting()
    {
        SetState(State.LEVELSTARTING);
    }

    public void SetGameRunning()
    {
        SetState(State.GAMERUNNING);
    }

    public void SetGamePaused()
    {
        SetState(State.GAMEPAUSED);
    }

    public void SetLevelEnding()
    {
        SetState(State.LEVELENDING);
    }

    public void SetSceneUnloading()
    {
        SetState(State.SCENEUNLOADING);
    }
}
