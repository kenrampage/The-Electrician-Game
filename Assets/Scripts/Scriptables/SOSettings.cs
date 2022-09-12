using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class SOSettings : ScriptableObject
{
    [Header("Controller")]
    [SerializeField] private float _lookSensitivity = .8f;
    [Space(10)]
    [SerializeField] private float _lookSensitivityMin = .1f;
    [SerializeField] private float _lookSensitivityMax = 2f;

    [Space(20)]
    [Header("Audio")]
    [SerializeField] private float _volumeSFX = .8f;
    [SerializeField] private float _volumeMusic = .8f;
    [Space(10)]
    [SerializeField] private float _volumeMin = 0f;
    [SerializeField] private float _volumeMax = 1f;

    [Header("Events")]
    [HideInInspector] public UnityEvent OnLookSensitivityChanged;
    [HideInInspector] public UnityEvent OnSFXVolumeChanged;
    [HideInInspector] public UnityEvent OnMusicVolumeChanged;


    #region Look Sensitivity Functions
    public void SetLookSensitivity(float f)
    {
        f = (Mathf.Round(f * 10f) * .1f);

        if (f != _lookSensitivity)
        {
            if (f < _lookSensitivityMin)
            {
                _lookSensitivity = _lookSensitivityMin;
            }

            if (f > _lookSensitivityMax)
            {
                _lookSensitivity = _lookSensitivityMax;
            }

            if (f <= _lookSensitivityMax && f >= _lookSensitivityMin)
            {
                _lookSensitivity = f;
            }

            OnLookSensitivityChanged?.Invoke();
        }
    }

    public void IncrementLookSensitivity()
    {
        SetLookSensitivity(_lookSensitivity + .1f);
        OnLookSensitivityChanged?.Invoke();
    }

    public void DecrementLookSensitivity()
    {
        SetLookSensitivity(_lookSensitivity - .1f);
        OnLookSensitivityChanged?.Invoke();
    }

    public float GetLookSensitivity()
    {
        return _lookSensitivity;
    }
    #endregion

    #region SFX Volume Functions
    public void SetSFXVolume(float f)
    {
        f = (Mathf.Round(f * 10f) * .1f);

        if (f != _volumeSFX)
        {
            if (f < _volumeMin)
            {
                _volumeSFX = _volumeMin;
            }

            if (f > _volumeMax)
            {
                _volumeSFX = _volumeMax;
            }

            if (f <= _volumeMax && f >= _volumeMin)
            {
                _volumeSFX = f;
            }

            OnSFXVolumeChanged?.Invoke();
        }
    }

    public void IncrementSFXVolume()
    {
        SetSFXVolume(_volumeSFX + .1f);
        OnSFXVolumeChanged?.Invoke();
    }

    public void DecrementSFXVolume()
    {
        SetSFXVolume(_volumeSFX - .1f);
        OnSFXVolumeChanged?.Invoke();
    }

    public float GetSFXVolume()
    {
        return _volumeSFX;
    }
    #endregion

    #region Music Volume Functions
    public void SetMusicVolume(float f)
    {
        f = (Mathf.Round(f * 10f) * .1f);

        if (f != _volumeMusic)
        {
            if (f < _volumeMin)
            {
                _volumeMusic = _volumeMin;
            }

            if (f > _volumeMax)
            {
                _volumeMusic = _volumeMax;
            }

            if (f <= _volumeMax && f >= _volumeMin)
            {
                _volumeMusic = f;
            }

            OnMusicVolumeChanged?.Invoke();
        }
    }

    public void IncrementMusicVolume()
    {
        SetMusicVolume(_volumeMusic + .1f);
        OnMusicVolumeChanged?.Invoke();
    }

    public void DecrementMusicVolume()
    {
        SetMusicVolume(_volumeMusic - .1f);
        OnMusicVolumeChanged?.Invoke();
    }

    public float GetMusicVolume()
    {
        return _volumeMusic;
    }
    #endregion

}
