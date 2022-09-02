using UnityEngine;

public class FMODMusicPlayer : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private SOFMODMusicData _fmodMusicData;

    private FMOD.Studio.EventInstance eventInstance;

    // public FMOD.Studio.PLAYBACK_STATE playbackState;
    // public bool isPaused;

    private void Awake()
    {
        RegisterEventListeners();
        InitializePlayer();
    }

    private void RegisterEventListeners()
    {
        _fmodMusicData.PlaybackStartEvent.AddListener(StartPlayback);
        _fmodMusicData.PlaybackStopEvent.AddListener(StopPlayback);
        _fmodMusicData.SetSectionEvent.AddListener(SetSection);
        _fmodMusicData.SetHighPassOnEvent.AddListener(SetHighpassOn);
        _fmodMusicData.SetHighPassOffEvent.AddListener(SetHighpassOff);
    }

    private void SetEventInstance()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(_fmodMusicData.FmodEvents[_fmodMusicData.EventIndex]);
    }

    public void RandomizeEventIndex()
    {
        _fmodMusicData.EventIndex = Random.Range(0, _fmodMusicData.FmodEvents.Length - 1);
    }

    public void InitializePlayer()
    {
        eventInstance.release();

        if (_fmodMusicData.IsShuffleOn)
        {
            RandomizeEventIndex();
        }

        SetEventInstance();
        // GetPlaybackState();
    }

    // private void GetPlaybackState()
    // {
    //     eventInstance.getPlaybackState(out playbackState);
    //     eventInstance.getPaused(out isPaused);
    // }

    // public void TogglePause()
    // {
    //     GetPlaybackState();

    //     if (playbackState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
    //     {
    //         StartPlayback();
    //     }
    //     else if (playbackState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
    //     {


    //         if (isPaused)
    //         {
    //             PausePlayback();
    //         }
    //         else
    //         {
    //             UnpausePlayback();
    //         }
    //     }
    // }

    [ContextMenu("Pause Music")]
    public void PausePlayback()
    {
        eventInstance.setPaused(true);
    }

    public void UnpausePlayback()
    {
        eventInstance.setPaused(false);
    }

    [ContextMenu("Play Music")]
    public void StartPlayback()
    {
        eventInstance.start();
    }

    [ContextMenu("Stop Music")]
    public void StopPlayback()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void SetSection()
    {
        eventInstance.setParameterByName("Section", _fmodMusicData.Section);
    }

    public void SetHighpassOn()
    {
        eventInstance.setParameterByName("HighPass", 1);
    }

    public void SetHighpassOff()
    {
        eventInstance.setParameterByName("HighPass", 0);
    }

    public void SetParameterByName(string parameterName, float value)
    {
        eventInstance.setParameterByName(parameterName, value);
    }
}
