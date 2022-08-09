using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMaterialEmission : MonoBehaviour
{
    private Material _material;

    public void TurnEmissionOn()
    {
        GetReferences();
        _material.EnableKeyword("_EMISSION");
    }

    public void TurnEmissionOff()
    {
        GetReferences();
        _material.DisableKeyword("_EMISSION");
    }

    private void GetReferences()
    {
        if (_material is null)
        {
            _material = GetComponent<Renderer>().material;
        }

    }

    public void ToggleEmission()
    {
        if (_material.IsKeywordEnabled("_EMISSION"))
        {
            TurnEmissionOff();
        }
        else
        {
            TurnEmissionOn();
        }
    }
}
