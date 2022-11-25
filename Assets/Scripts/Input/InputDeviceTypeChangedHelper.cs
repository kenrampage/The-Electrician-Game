using UnityEngine;

public class InputDeviceTypeChangedHelper : MonoBehaviour
{
    private InputManager _inputManager;

    [Header("References")]
    [SerializeField] private GameObject[] _mkbObjects;
    [SerializeField] private GameObject[] _gamepadObjects;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        _inputManager.OnInputDeviceTypeChanged.AddListener(HandleInputDeviceTypeChanged);
    }

    public void HandleInputDeviceTypeChanged()
    {
        switch (_inputManager.CurrentInputDeviceType)
        {
            case InputDeviceType.MKB:
            TurnMKBObjectsOn();
            break;

            case InputDeviceType.GAMEPAD:
            TurnGamepadObjectsOn();
            break;

            default:
            break;
        }
    }

    private void TurnMKBObjectsOn()
    {
        foreach (var obj in _gamepadObjects)
        {
            obj.SetActive(false);
        }

        foreach (var obj in _mkbObjects)
        {
            obj.SetActive(true);
        }
    }

    private void TurnGamepadObjectsOn()
    {
        foreach (var obj in _mkbObjects)
        {
            obj.SetActive(false);
        }

        foreach (var obj in _gamepadObjects)
        {
            obj.SetActive(true);
        }
    }
}
