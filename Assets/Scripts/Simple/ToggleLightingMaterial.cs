using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightingMaterial : MonoBehaviour
{
    private Material _targetMaterial;
    private bool _isOn = false;

    [Header("Materials")]
    [SerializeField] private Material _offMaterial;
    [SerializeField] private Material _onMaterial;


    private void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        if (_targetMaterial is null)
        {
            _targetMaterial = GetComponent<Renderer>().material;
        }
    }

    public void TurnLightOn()
    {
        GetReferences();
        _targetMaterial.CopyPropertiesFromMaterial(_onMaterial);
        _isOn = true;
    }

    public void TurnLightOff()
    {
        GetReferences();
        _targetMaterial.CopyPropertiesFromMaterial(_offMaterial);
        _isOn = false;
    }

    public void ToggleLight()
    {
        if (_isOn)
        {
            TurnLightOff();
        }
        else
        {
            TurnLightOn();
        }
    }

}
