using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private SOSessionData _sessionData;

    [Header("Events")]
    [SerializeField] private SerializedEvent[] onSceneLoadEvents;
    [SerializeField] private SerializedEvent[] onSplashScreenActiveEvents;
    [SerializeField] private SerializedEvent[] onMenuActiveEvents;
    [SerializeField] private SerializedEvent[] onSceneUnloadEvents;

    public enum State
    {
        INIT,
        SCENELOADING,
        SPLASHSCREENACTIVE,
        MENUACTIVE,
        SCENEUNLOADING
    }

    private State _stateCurrent;
    private State _statePrev;

    private void OnEnable()
    {
        ResetStates();

        if (_sessionData.GetSplashScreenStatus())
        {
            SetState(State.SPLASHSCREENACTIVE);
        }
        else
        {
            SetState(State.MENUACTIVE);
        }

    }

    // Respond to state changes by cycling through the array of serialized unity events
    private void HandleStateChange()
    {
        switch (_stateCurrent)
        {
            case State.SCENELOADING:
                StartCycleThroughEvents(onSceneLoadEvents);
                break;

            case State.SPLASHSCREENACTIVE:
                StartCycleThroughEvents(onSplashScreenActiveEvents);
                break;

            case State.MENUACTIVE:
                StartCycleThroughEvents(onMenuActiveEvents);
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
            yield return new WaitForSeconds(array[i].Delay);

            array[i].InvokeEvent();

        }
    }

    public void SetState(State state)
    {
        if (state != _stateCurrent)
        {
            _statePrev = _stateCurrent;
            _stateCurrent = state;
            HandleStateChange();
        }
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

    public void SetSplashScreenActive()
    {
        SetState(State.SPLASHSCREENACTIVE);
    }

    public void SetMenuActive()
    {
        SetState(State.MENUACTIVE);
        _sessionData.TurnSplashScreenOff();
    }

    public void SetSceneUnloading()
    {
        SetState(State.SCENEUNLOADING);
    }
}
