using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings")]
public class SOSettings : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] private float _lookSensitivity = .8f;
    [SerializeField] private float _lookSensitivityMin = .1f;
    [SerializeField] private float _lookSensitivityMax = 2f;

    [Space(10)]
    private float _volumeSFX;
    private float _volumeMusic;

    [HideInInspector] public UnityEvent OnLookSensitivityChanged;

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
}
