using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections.Generic;

public enum InputDeviceType
{
    MKB,
    XBOX,
}

[RequireComponent(typeof(PlayerInput))]
// Receives messages from player input component and allows easier management of responses via unity events
public class InputManager : Singleton<InputManager>
{
    #region UnityEvents
    [Header("Events")]
    public UnityEvent OnPauseEvent;
    public UnityEvent OnUnpauseEvent;
    public UnityEvent OnEndTestEvent;

    [HideInInspector] public UnityEvent OnItemNextEvent;
    [HideInInspector] public UnityEvent OnItemPrevEvent;
    [HideInInspector] public UnityEvent OnInteractEvent;
    [HideInInspector] public UnityEvent OnCancelEvent;
    [HideInInspector] public UnityEvent OnToggleXrayEvent;
    #endregion

    private PlayerInput _playerInput;

    #region Properties
    private Vector2 _moveInput;
    public Vector2 MoveInput
    {
        get { return _moveInput; }
    }

    private Vector2 _lookInput;
    public Vector2 LookInput
    {
        get { return _lookInput; }
    }

    private bool _sprintInput;
    public bool SprintInput
    {
        get { return _sprintInput; }
    }

    private bool _jumpInput = false;
    public bool JumpInput
    {
        get { return _jumpInput; }
    }

    private InputDeviceType _currentInputDevice = InputDeviceType.MKB;
    public InputDeviceType CurrentInputDevice
    {
        get { return _currentInputDevice; }
    }

    private bool _isAnalogInput = false;
    public bool IsAnalogInput
    {
        get { return _isAnalogInput; }
    }
    #endregion

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Various functions for changing user input settings
    #region Input Settings
    public void SwitchToMenuInput()
    {
        _playerInput.SwitchCurrentActionMap("Menu");
    }

    public void SwitchToPlayerInput()
    {
        _playerInput.SwitchCurrentActionMap("Player");
    }

    public void CursorLockOn()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    public void CursorLockOff()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Receive Messages from Player Input component
    // public void OnControlsChanged(InputValue value)
    // {
    //     // handle changes to input device
    // }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        _lookInput = value.Get<Vector2>();
    }

    public void OnSprint(InputValue value)
    {
        _sprintInput = value.isPressed;
    }

    public void OnInteract(InputValue value)
    {
        OnInteractEvent?.Invoke();
    }

    public void OnCancel(InputValue value)
    {
        OnCancelEvent?.Invoke();
    }

    public void OnPause(InputValue value)
    {
        OnPauseEvent?.Invoke();
    }

    public void OnUnpause(InputValue value)
    {
        OnUnpauseEvent?.Invoke();
    }

    public void OnNextItem(InputValue value)
    {
        OnItemNextEvent?.Invoke();
    }

    public void OnPrevItem(InputValue value)
    {
        OnItemPrevEvent?.Invoke();
    }

    public void OnXray(InputValue value)
    {
        OnToggleXrayEvent?.Invoke();
    }

    public void OnEndTest(InputValue value)
    {
        OnEndTestEvent?.Invoke();
    }
    #endregion

}
