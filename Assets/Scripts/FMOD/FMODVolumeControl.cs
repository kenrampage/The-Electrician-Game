using UnityEngine;
using FMODUnity;

public class FMODVolumeControl : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] private SOSettings _soSettings;

    [Header("FMOD VCAs")]
    [SerializeField] private string _vcaSFXName;
    [SerializeField] private string _vcaMusicName;

    private FMOD.Studio.VCA _vcaSFX;
    private FMOD.Studio.VCA _vcaMusic;


    private void Awake()
    {
        GetVCAReferences();
        RegisterEventListeners();
    }

    private void RegisterEventListeners()
    {
        _soSettings.OnMusicVolumeChanged?.AddListener(SetVolumeMusic);
        _soSettings.OnSFXVolumeChanged?.AddListener(SetVolumeSFX);
    }

    private void GetVCAReferences()
    {
        _vcaSFX = FMODUnity.RuntimeManager.GetVCA("vca:/" + _vcaSFXName);
        _vcaMusic = FMODUnity.RuntimeManager.GetVCA("vca:/" + _vcaMusicName);
    }

    #region Get/Set Functions
    public void SetVolumeSFX()
    {
        _vcaSFX.setVolume(_soSettings.GetSFXVolume());
    }

    public float GetVolumeSFX()
    {
        float v;
        _vcaSFX.getVolume(out v);
        return v;
    }

    public void SetVolumeMusic()
    {
        _vcaMusic.setVolume(_soSettings.GetMusicVolume());
    }

    public float GetVolumeMusic()
    {
        float v;
        _vcaMusic.getVolume(out v);
        return v;
    }
    #endregion

}
