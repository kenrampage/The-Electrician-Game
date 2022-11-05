using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "DialogueData_", menuName = "Scriptable Objects/Dialogue")]
public class SODialogueData : ScriptableObject
{
    [Header("Text")]
    [SerializeField] private string _name;
    [SerializeField] private DialogueLine[] _messageArray;

    [Header("Settings")]
    [SerializeField] private TMP_FontAsset _fontAsset;
    [SerializeField] private Color32 _fontColor;
    [SerializeField] private float _charInterval;

    [SerializeField] private int _index;

    public void ResetIndex()
    {
        _index = 0;
    }

    public void IncrementIndex()
    {
        if (_index >= _messageArray.Length - 1)
        {
            Debug.Log("Dialogue with " + _name + " over");
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
            Debug.Log("Dialogue with " + _name + " is at the beginning");
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
}
