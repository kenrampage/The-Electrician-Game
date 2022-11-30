using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Input Action Map Change Trigger", menuName = "Input/Input Action Map Change Trigger")]
public class SOTriggerInputActionMapChange : ScriptableObject
{
    [HideInInspector] public UnityEvent TriggerSwitchToMenuInput;
    [HideInInspector] public UnityEvent TriggerSwitchToGameMenuInput;
    [HideInInspector] public UnityEvent TriggerSwitchToPlayerInput;
    [HideInInspector] public UnityEvent TriggerSwitchToDialogueInput;

    public void SwitchToMenuInput()
    {
        TriggerSwitchToMenuInput?.Invoke();
    }

    public void SwitchToGameMenuInput()
    {
        TriggerSwitchToGameMenuInput?.Invoke();
    }

    public void SwitchToPlayerInput()
    {
        TriggerSwitchToPlayerInput?.Invoke();
    }

    public void SwitchToDialogueInput()
    {
        TriggerSwitchToDialogueInput?.Invoke();
    }

}
