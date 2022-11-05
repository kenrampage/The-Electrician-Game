using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRemoteTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SODialogueData _data;
    [SerializeField] private SODialogueBoxRemote _remote;

    [Header("Settings")]
    [SerializeField] private bool _resetIndexOnAwake;

    [ContextMenu("Start Dialogue")]
    public void StartDialogue()
    {
        _remote.Data = _data;
        _data.ResetIndex();
        _remote.DialogueOn();
    }

    // private void Awake()
    // {
    //     if (_resetIndexOnAwake)
    //     {
    //         _data.ResetIndex();
    //     }
    // }

}
