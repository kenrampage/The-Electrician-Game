using UnityEngine;
using UnityEngine.Events;

// For passing SODialogueData between DialogueRemoteTrigger script and DialogueBoxManager script
[CreateAssetMenu(fileName = "DialogueRemote", menuName = "Scriptable Objects/Dialogue Remote")]
public class SODialogueBoxRemote : ScriptableObject
{
    [Header("References")]
    public SODialogueData Data;

    [Header("Events")]
    [HideInInspector] public UnityEvent EventDialogueOn;
    [HideInInspector] public UnityEvent EventDialogueOff;
    [HideInInspector] public UnityEvent EventDialogueStart;
    [HideInInspector] public UnityEvent EventDialogueNext;
    [HideInInspector] public UnityEvent EventDialoguePrev;

    public void DialogueOn()
    {
        EventDialogueOn?.Invoke();
    }

    public void DialogueOff()
    {
        EventDialogueOff?.Invoke();
    }

    public void DialogueStart()
    {
        EventDialogueStart?.Invoke();
    }

    public void DialogueNext()
    {
        EventDialogueNext?.Invoke();
    }

    public void DialoguePrev()
    {
        EventDialoguePrev?.Invoke();
    }
}
