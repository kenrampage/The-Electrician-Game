using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISettingsVolumeMusic : MonoBehaviour
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
        _valueText.text = _soSettings.GetMusicVolume().ToString();
    }

    public void IncrementVolume()
    {
        _soSettings.IncrementMusicVolume();
        UpdateText();
    }

    public void DecrementVolume()
    {
        _soSettings.DecrementMusicVolume();
        UpdateText();
    }
}
