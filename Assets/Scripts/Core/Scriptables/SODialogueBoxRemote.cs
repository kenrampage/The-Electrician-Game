using UnityEngine;
using UnityEngine.Events;

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

    [ContextMenu("Dialogue On")]
    public void DialogueOn()
    {
        EventDialogueOn?.Invoke();
    }

    [ContextMenu("Dialogue Off")]
    public void DialogueOff()
    {
        EventDialogueOff?.Invoke();
    }

    [ContextMenu("Dialogue Start")]
    public void DialogueStart()
    {
        EventDialogueStart?.Invoke();
    }

    [ContextMenu("Dialogue Next")]
    public void DialogueNext()
    {
        EventDialogueNext?.Invoke();
    }

    [ContextMenu("Dialogue Prev")]
    public void DialoguePrev()
    {
        EventDialoguePrev?.Invoke();
    }
}
