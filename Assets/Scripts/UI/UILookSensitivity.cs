using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILookSensitivity : MonoBehaviour
{
    [Header("Settings Scriptable Object")]
    [SerializeField] private SOSettings _settings;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI _valueText;

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _valueText.text = _settings.GetLookSensitivity().ToString();
    }

    public void IncrementLookSensitivity()
    {
        _settings.IncrementLookSensitivity();
        UpdateText();
    }

    public void DecrementLookSensitivity()
    {
        _settings.DecrementLookSensitivity();
        UpdateText();
    }
}
