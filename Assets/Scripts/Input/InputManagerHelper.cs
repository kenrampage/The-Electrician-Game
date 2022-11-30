using UnityEngine;
using UnityEngine.Events;

// Subscribes to specific input event in Inputmanager based on the Input Type chosen in the inspector
public class InputManagerHelper : MonoBehaviour
{
    private InputManager _inputManager;

    private enum InputType
    {
        PAUSE,
        UNPAUSE,
        ITEMNEXT,
        ITEMPREV,
        INTERACT,
        CANCEL,
        XRAY,
        DIALOGUECONTINUE
    }

    [Header("Settings")]
    [SerializeField] private InputType _inputType;

    [Header("Event")]
    [SerializeField] private UnityEvent _eventToInvoke;

    void Awake()
    {
        _inputManager = InputManager.Instance;
        SubscribeToInputEvent();
    }

    private void InvokeEvent()
    {
        _eventToInvoke?.Invoke();
    }

    private void SubscribeToInputEvent()
    {
        switch (_inputType)
        {
            case InputType.PAUSE:
                _inputManager.OnPauseEvent.AddListener(InvokeEvent);
                break;

            case InputType.UNPAUSE:
                _inputManager.OnUnpauseEvent.AddListener(InvokeEvent);
                break;

            case InputType.ITEMNEXT:
                _inputManager.OnItemNextEvent.AddListener(InvokeEvent);
                break;

            case InputType.ITEMPREV:
                _inputManager.OnItemPrevEvent.AddListener(InvokeEvent);
                break;

            case InputType.INTERACT:
                _inputManager.OnInteractEvent.AddListener(InvokeEvent);
                break;

            case InputType.CANCEL:
                _inputManager.OnCancelEvent.AddListener(InvokeEvent);
                break;

            case InputType.XRAY:
                _inputManager.OnToggleXrayEvent.AddListener(InvokeEvent);
                break;

            case InputType.DIALOGUECONTINUE:
                _inputManager.OnDialogueContinueEvent.AddListener(InvokeEvent);
                break;

            default:
                break;
        }
    }
}
