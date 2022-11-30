using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reads data from SODialogueData scriptable object then feeds it into the SODialogueBoxRemote Scriptable Object which controls the
// DialogueBoxManager script
public class DialogueRemoteTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SODialogueData _data;
    [SerializeField] private SODialogueBoxRemote _remote;

    [ContextMenu("Start Dialogue")]
    public void StartDialogue()
    {
        _remote.Data = _data;
        _data.ResetIndex();
        _remote.DialogueOn();
    }

    [ContextMenu("End Dialogue")]
    public void EndDialogue()
    {
        _remote.DialogueOff();
    }

}
