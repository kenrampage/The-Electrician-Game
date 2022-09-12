using System.Collections;
using UnityEngine;

// Manages current and previous game state and invokes a serialized array of events in response to state changes
public class GameStateManager : Singleton<GameStateManager>
{
    [Header("Scriptable Objects")]
    [SerializeField] private SOGameStateControl _soGameStateControl;
    [SerializeField] private SOGameStateHelper _soGameStateHelper;

    [Header("Events")]
    [SerializeField] private SerializedEvent[] _sceneLoadEvents;
    [SerializeField] private SerializedEvent[] _levelStartEvents;
    [SerializeField] private SerializedEvent[] _gameRunEvents;
    [SerializeField] private SerializedEvent[] _gamePauseEvents;
    [SerializeField] private SerializedEvent[] _gameUnpauseEvents;
    [SerializeField] private SerializedEvent[] _levelEndEvents;
    [SerializeField] private SerializedEvent[] _sceneUnloadEvents;

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

    private void Awake()
    {
        RegisterEventListeners();
    }

    private void OnEnable()
    {
        ResetStates();
        SetState(State.SCENELOADING);
    }

    private void RegisterEventListeners()
    {
        _soGameStateControl.OnSceneLoad.AddListener(SetSceneLoading);
        _soGameStateControl.OnLevelStart.AddListener(SetLevelStarting);
        _soGameStateControl.OnGameRun.AddListener(SetGameRunning);
        _soGameStateControl.OnGamePause.AddListener(SetGamePaused);
        _soGameStateControl.OnLevelEnd.AddListener(SetLevelEnding);
        _soGameStateControl.OnSceneUnload.AddListener(SetSceneUnloading);
    }


    // Respond to state changes by cycling through the array of serialized unity events
    private void HandleStateChange()
    {
        switch (_stateCurrent)
        {
            case State.SCENELOADING:
                StartCycleThroughEvents(_sceneLoadEvents);
                break;

            case State.LEVELSTARTING:
                StartCycleThroughEvents(_levelStartEvents);
                break;

            case State.GAMERUNNING:
                if (_statePrev == State.LEVELSTARTING)
                {
                    StartCycleThroughEvents(_gameRunEvents);
                }
                else if (_statePrev == State.GAMEPAUSED)
                {
                    StartCycleThroughEvents(_gameUnpauseEvents);
                }
                break;

            case State.GAMEPAUSED:
                StartCycleThroughEvents(_gamePauseEvents);
                break;

            case State.LEVELENDING:
                StartCycleThroughEvents(_levelEndEvents);
                break;

            case State.SCENEUNLOADING:
                StartCycleThroughEvents(_sceneUnloadEvents);
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
        _soGameStateHelper.OnSceneLoad?.Invoke();
    }

    public void SetLevelStarting()
    {
        SetState(State.LEVELSTARTING);
        _soGameStateHelper.OnLevelStart?.Invoke();
    }

    public void SetGameRunning()
    {
        SetState(State.GAMERUNNING);
        _soGameStateHelper.OnGameRun?.Invoke();
    }

    public void SetGamePaused()
    {
        SetState(State.GAMEPAUSED);
        _soGameStateHelper.OnGamePause?.Invoke();
    }

    public void SetLevelEnding()
    {
        SetState(State.LEVELENDING);
        _soGameStateHelper.OnLevelEnd?.Invoke();
    }

    public void SetSceneUnloading()
    {
        SetState(State.SCENEUNLOADING);
        _soGameStateHelper.OnSceneUnload?.Invoke();
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
