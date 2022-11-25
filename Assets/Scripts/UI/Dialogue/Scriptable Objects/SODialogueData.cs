using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

[CreateAssetMenu(fileName = "DialogueData_", menuName = "Scriptable Objects/Dialogue")]
public class SODialogueData : ScriptableObject
{
    [Header("Text")]
    [SerializeField] private string _name;
    [SerializeField] private DialogueLine[] _messageArray;

    [Header("Audio")]
    [SerializeField] private EventReference _fmodEvent;

    [Header("Settings")]
    [SerializeField] private TMP_FontAsset _fontAsset;
    [SerializeField] private Color32 _fontColor;
    [SerializeField] private float _charInterval;
    [SerializeField] private float _pageDelay;
    [SerializeField] private bool _requireInput;
    [SerializeField] private WalkieEffectType _walkieEffectType;

    private int _index;

    public void ResetIndex()
    {
        _index = 0;
    }

    public void IncrementIndex()
    {
        if (_index >= _messageArray.Length - 1)
        {
            return;
        }
        else
        {
            _index++;
        }

    }

    public void DecrementIndex()
    {
        if (_index <= 0)
        {
            return;
        }
        else
        {
            _index--;
        }

    }

    public string GetMessageText()
    {
        return _messageArray[_index].Line;
    }

    public string GetNameText()
    {
        return _name;
    }

    public Color GetNameColor()
    {
        return _fontColor;
    }

    public TMP_FontAsset GetFontAsset()
    {
        return _fontAsset;
    }

    public float GetCharInterval()
    {
        return _charInterval;
    }

    public float GetPageDelay()
    {
        return _pageDelay;
    }

    public bool CheckifInputRequired()
    {
        return _requireInput;
    }

    public EventReference GetFmodEvent()
    {
        return _fmodEvent;
    }

    public WalkieEffectType GetWalkieEffectType()
    {
        return _walkieEffectType;
    }

    public bool CheckIfLastMessage()
    {
        if (_index >= _messageArray.Length - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckIfFirstMessage()
    {
        if (_index <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
