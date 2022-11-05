using UnityEngine;
using FMODUnity;
using System;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FMODMusicData_", menuName = "FMOD/FMODMusicData")]
public class SOFMODMusicData : ScriptableObject
{
    [Header("Fmod Event Settings")]
    public int EventIndex;
    public EventReference[] FmodEvents;
    
    [Header("Settings")]
    public int Section;
    public bool IsShuffleOn;

    [HideInInspector] public UnityEvent PauseToggleEvent;
    [HideInInspector] public UnityEvent PlaybackStartEvent;
    [HideInInspector] public UnityEvent PlaybackStopEvent;
    [HideInInspector] public UnityEvent SetSectionEvent;
    [HideInInspector] public UnityEvent SetHighPassOnEvent;
    [HideInInspector] public UnityEvent SetHighPassOffEvent;

    public void TogglePause()
    {
        PauseToggleEvent?.Invoke();
    }

    public void StartPlayback()
    {
        PlaybackStartEvent?.Invoke();
    }

    public void StopPlayback()
    {
        PlaybackStopEvent?.Invoke();
    }

    public void SetSection(int value)
    {
        Section = value;
        SetSectionEvent?.Invoke();
    }

    public void SetHighpassOn()
    {
        SetHighPassOnEvent?.Invoke();
    }

    public void SetHighPassOff()
    {
        SetHighPassOffEvent?.Invoke();
    }

}
