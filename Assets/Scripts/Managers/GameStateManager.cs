using System.Collections;
using UnityEngine;

// Manages current and previous game state and invokes a serialized array of events in response to state changes
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

    private State _stateCurrent;
    private State _statePrev;

    [Header("Events")]
    [SerializeField] private SerializedEvent[] onSceneLoadEvents;
    [SerializeField] private SerializedEvent[] onLevelStartEvents;
    [SerializeField] private SerializedEvent[] onGameRunEvents;
    [SerializeField] private SerializedEvent[] onGamePauseEvents;
    [SerializeField] private SerializedEvent[] onGameUnpauseEvents;
    [SerializeField] private SerializedEvent[] onLevelEndEvents;
    [SerializeField] private SerializedEvent[] onSceneUnloadEvents;


    private void OnEnable()
    {
        ResetStates();
        SetState(State.SCENELOADING);
    }


    // Respond to state changes by cycling through the array of serialized unity events
    private void HandleStateChange()
    {
        switch (_stateCurrent)
        {
            case State.SCENELOADING:
                StartCycleThroughEvents(onSceneLoadEvents);
                break;

            case State.LEVELSTARTING:
                StartCycleThroughEvents(onLevelStartEvents);
                break;

            case State.GAMERUNNING:
                if (_statePrev == State.LEVELSTARTING)
                {
                    StartCycleThroughEvents(onGameRunEvents);
                }
                else if (_statePrev == State.GAMEPAUSED)
                {
                    StartCycleThroughEvents(onGameUnpauseEvents);
                }
                break;

            case State.GAMEPAUSED:
                StartCycleThroughEvents(onGamePauseEvents);
                break;

            case State.LEVELENDING:
                StartCycleThroughEvents(onLevelEndEvents);
                break;

            case State.SCENEUNLOADING:
                StartCycleThroughEvents(onSceneUnloadEvents);
                break;

            default:
                break;
        }
    }

    public void StartCycleThroughEvents(SerializedEvent[] array)
    {
        StartCoroutine(CycleThroughEvents(array));
    }

    private IEnumerator CycleThroughEvents(SerializedEvent[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            yield return new WaitForSecondsRealtime(array[i].Delay);

            array[i].InvokeEvent();

        }
    }


    #region State Set/Get Functions
    public void SetState(State state)
    {
        if (state != _stateCurrent)
        {
            _statePrev = _stateCurrent;
            _stateCurrent = state;
            HandleStateChange();
        }
    }

    public State GetState()
    {
        return _stateCurrent;
    }

    private void ResetStates()
    {
        _stateCurrent = State.INIT;
        _statePrev = State.INIT;
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
    #endregion

    #region Handle Input Functions
    public void HandlePauseInput()
    {
        SetGamePaused();
    }

    public void HandleUnpauseInput()
    {
        SetGameRunning();
    }

    public void HandleEndTestInput()
    {
        SetLevelEnding();
    }
    #endregion
}
