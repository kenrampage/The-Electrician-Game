using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISettingsVolumeSFX : MonoBehaviour
{
    [Header("Settings Scriptable Object")]
    [SerializeField] private SOSettings _soSettings;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI _valueText;

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _valueText.text = _soSettings.GetSFXVolume().ToString();
    }

    public void IncrementVolume()
    {
        _soSettings.IncrementSFXVolume();
        UpdateText();
    }

    public void DecrementVolume()
    {
        _soSettings.DecrementSFXVolume();
        UpdateText();
    }
}
