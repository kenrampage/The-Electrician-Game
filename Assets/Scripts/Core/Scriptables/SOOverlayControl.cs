using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SOOverlayControl", menuName = "Scriptable Objects/OverlayControl")]
public class SOOverlayControl : ScriptableObject
{
    [HideInInspector] public UnityEvent OnSplashScreenOn;
    [HideInInspector] public UnityEvent OnSplashScreenOff;
    [HideInInspector] public UnityEvent OnMainMenuOn;
    [HideInInspector] public UnityEvent OnMainMenuOff;
    [HideInInspector] public UnityEvent OnSceneLoad;
    [HideInInspector] public UnityEvent OnSceneUnload;
    [HideInInspector] public UnityEvent OnStartUIOn;
    [HideInInspector] public UnityEvent OnStartUIOff;
    [HideInInspector] public UnityEvent OnStartUIOut;
    [HideInInspector] public UnityEvent OnPauseUIOn;
    [HideInInspector] public UnityEvent OnPauseUIOff;
    [HideInInspector] public UnityEvent OnPauseUIOut;
    [HideInInspector] public UnityEvent OnEndUIOn;
    [HideInInspector] public UnityEvent OnEndUIOff;
    [HideInInspector] public UnityEvent OnEndUIOut;

    public void SplashScreenOn()
    {
        OnSplashScreenOn?.Invoke();
    }

    public void SplashScreenOff()
    {
        OnSplashScreenOff?.Invoke();
    }

    public void MainMenuOn()
    {
        OnMainMenuOn?.Invoke();
    }

    public void MainMenuOff()
    {
        OnMainMenuOff?.Invoke();
    }

    public void SceneLoad()
    {
        OnSceneLoad?.Invoke();
    }

    public void SceneUnload()
    {
        OnSceneUnload?.Invoke();
    }

    public void StartUIOn()
    {
        OnStartUIOn?.Invoke();
    }

    public void StartUIOff()
    {
        OnStartUIOff?.Invoke();
    }

    public void StartUIOut()
    {
        OnStartUIOut?.Invoke();
    }

    public void PauseUIOn()
    {
        OnPauseUIOn?.Invoke();
    }

    public void PauseUIOff()
    {
        OnPauseUIOff?.Invoke();
    }

    public void PauseUIOut()
    {
        OnPauseUIOut?.Invoke();
    }

    public void EndUIOn()
    {
        OnEndUIOn?.Invoke();
    }

    public void EndUIOff()
    {
        OnEndUIOff?.Invoke();
    }

    public void EndUIOut()
    {
        OnEndUIOut?.Invoke();
    }



}

