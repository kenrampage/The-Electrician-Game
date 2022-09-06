using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RampageUtils;

[System.Serializable]
public class Equipment
{
    public enum Type
    {
        INTERACTABLE,
        WALLON,
        WALLOFF,
        WIRABLE
    }

    public ToggleTargetObjects UIMarker;
    public GameObject Cursor;
    public LayerMask LayerMask;
    public string Tag;
    public Type TargetType;

}

