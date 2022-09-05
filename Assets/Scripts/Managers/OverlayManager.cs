using UnityEngine;
using System.Collections;

// For easier management of overlay objects used for transitioning between scenes and menus
public class OverlayManager : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] private SOOverlayControl _overlayControl;

    [Header("Events")]
    [SerializeField] private SerializedEvent[] _splashScreenOffEvents;
    [SerializeField] private SerializedEvent[] _mainMenuOnEvents;
    [SerializeField] private SerializedEvent[] _mainMenuOffEvents;
    [SerializeField] private SerializedEvent[] _sceneLoadEvents;
    [SerializeField] private SerializedEvent[] _sceneUnloadEvents;
    [SerializeField] private SerializedEvent[] _startUIOnEvents;
    [SerializeField] private SerializedEvent[] _startUIOffEvents;
    [SerializeField] private SerializedEvent[] _startUIOutEvents;
    [SerializeField] private SerializedEvent[] _pauseUIOnEvents;
    [SerializeField] private SerializedEvent[] _pauseUIOffEvents;
    [SerializeField] private SerializedEvent[] _pauseUIOutEvents;
    [SerializeField] private SerializedEvent[] _endUIOnEvents;
    [SerializeField] private SerializedEvent[] _endUIOffEvents;
    [SerializeField] private SerializedEvent[] _endUIOutEvents;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        RegisterEventListeners();
    }

    private void RegisterEventListeners()
    {
        _overlayControl.OnSplashScreenOff.AddListener(SplashScreenOff);

        _overlayControl.OnMainMenuOn.AddListener(MainMenuOn);
        _overlayControl.OnMainMenuOff.AddListener(MainMenuOff);

        _overlayControl.OnSceneLoad.AddListener(SceneLoad);
        _overlayControl.OnSceneUnload.AddListener(SceneUnload);

        _overlayControl.OnStartUIOn.AddListener(StartUIOn);
        _overlayControl.OnStartUIOff.AddListener(StartUIOff);
        _overlayControl.OnStartUIOut.AddListener(StartUIOut);

        _overlayControl.OnPauseUIOn.AddListener(PauseUIOn);
        _overlayControl.OnPauseUIOff.AddListener(PauseUIOff);
        _overlayControl.OnPauseUIOut.AddListener(PauseUIOut);

        _overlayControl.OnEndUIOn.AddListener(EndUIOn);
        _overlayControl.OnEndUIOff.AddListener(EndUIOff);
        _overlayControl.OnEndUIOut.AddListener(EndUIOut);
    }

    #region UI Methods

    [ContextMenu("SplashScreenOff")]
    private void SplashScreenOff()
    {
        StartCycleThroughEvents(_splashScreenOffEvents);
    }

    [ContextMenu("MainMenuOn")]
    private void MainMenuOn()
    {
        StartCycleThroughEvents(_mainMenuOnEvents);
    }

    [ContextMenu("MainMenuOff")]
    private void MainMenuOff()
    {
        StartCycleThroughEvents(_mainMenuOffEvents);
    }

    [ContextMenu("StartUIOn")]
    private void StartUIOn()
    {
        StartCycleThroughEvents(_startUIOnEvents);
    }

    [ContextMenu("SceneLoad")]
    private void SceneLoad()
    {
        StartCycleThroughEvents(_sceneLoadEvents);
    }

    [ContextMenu("SceneUnload")]
    private void SceneUnload()
    {
        StartCycleThroughEvents(_sceneUnloadEvents);
    }

    [ContextMenu("StartUIOff")]
    private void StartUIOff()
    {
        StartCycleThroughEvents(_startUIOffEvents);
    }

    [ContextMenu("StartUIOut")]
    private void StartUIOut()
    {
        StartCycleThroughEvents(_startUIOutEvents);
    }

    [ContextMenu("PauseUIOn")]
    private void PauseUIOn()
    {
        StartCycleThroughEvents(_pauseUIOnEvents);
    }

    [ContextMenu("PauseUIOff")]
    private void PauseUIOff()
    {
        StartCycleThroughEvents(_pauseUIOffEvents);
    }

    [ContextMenu("PauseUIOut")]
    private void PauseUIOut()
    {
        StartCycleThroughEvents(_pauseUIOutEvents);
    }

    [ContextMenu("EndUIOn")]
    private void EndUIOn()
    {
        print("End UI On Events triggered");
        StartCycleThroughEvents(_endUIOnEvents);
    }

    [ContextMenu("EndUIOff")]
    private void EndUIOff()
    {
        StartCycleThroughEvents(_endUIOffEvents);
    }

    [ContextMenu("EndUIOut")]
    private void EndUIOut()
    {
        
        StartCycleThroughEvents(_endUIOutEvents);
    }

    #endregion

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

}
