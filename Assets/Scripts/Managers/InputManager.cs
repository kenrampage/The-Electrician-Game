using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.Serialization;

// For passing int parameter via unity event
public class NumInputEvent : UnityEvent<int>
{ }

// Receives player input and allows easier management of responses via unity events
public class InputManager : Singleton<InputManager>
{
    #region UnityEvents
    [Header("Events")]
    public UnityEvent OnPause;
    public UnityEvent OnUnpause;
    public UnityEvent OnEndTest;
    [HideInInspector] public NumInputEvent OnNumInput;
    [HideInInspector] public UnityEvent OnItemNext;
    [HideInInspector] public UnityEvent OnItemPrev;
    [HideInInspector] public UnityEvent OnInteract;
    [HideInInspector] public UnityEvent OnInteractRelease;
    [HideInInspector] public UnityEvent OnCancel;
    [HideInInspector] public UnityEvent OnToggleFlashlight;
    [HideInInspector] public UnityEvent OnToggleXray;
    #endregion

    #region InputAction Variables
    [Header("Input")]
    [SerializeField] private InputActionAsset _inputActions;
    private InputActionMap _inputActionMapMenu;
    private InputActionMap _inputActionMapPlayer;

    private InputAction _interact;
    private InputAction _cancel;
    private InputAction _item1;
    private InputAction _item2;
    private InputAction _item3;
    private InputAction _item4;
    private InputAction _itemNext;
    private InputAction _itemPrev;
    private InputAction _toggleFlashlight;
    private InputAction _toggleXray;
    private InputAction _pause;
    private InputAction _unpause;
    private InputAction _endTest;
    #endregion

    #region Default Methods
    private void Awake()
    {
        CreateEventInstances();
        GetInputActionReferences();
    }

    private void OnEnable()
    {
        Enable_InputActions();
    }

    private void OnDisable()
    {
        Disable_InputActions();
    }
    #endregion

    private void CreateEventInstances()
    {
        if (OnNumInput == null)
        {
            OnNumInput = new NumInputEvent();
        }
    }

    // Get references to input actions and assign them to functions
    #region Input Action References
    private void GetInputActionReferences()
    {
        _inputActionMapMenu = _inputActions.FindActionMap("Menu");
        _inputActionMapPlayer = _inputActions.FindActionMap("Player");

        _endTest = _inputActionMapPlayer.FindAction("EndTest");
        _endTest.started += EndTest;

        _pause = _inputActionMapPlayer.FindAction("Pause");
        _pause.started += Pause;

        _unpause = _inputActionMapMenu.FindAction("Unpause");
        _unpause.started += Unpause;

        _interact = _inputActionMapPlayer.FindAction("Interact");
        _interact.started += Interact;
        _interact.canceled += InteractRelease;

        _toggleXray = _inputActionMapPlayer.FindAction("toggleXray");
        _toggleXray.performed += ToggleXray;

        _toggleFlashlight = _inputActionMapPlayer.FindAction("toggleFlashlight");
        _toggleFlashlight.performed += ToggleFlashlight;

        _cancel = _inputActionMapPlayer.FindAction("Cancel");
        _cancel.performed += Cancel;

        _item1 = _inputActionMapPlayer.FindAction("Item1");
        _item1.performed += EquipItem1;

        _item2 = _inputActionMapPlayer.FindAction("Item2");
        _item2.performed += EquipItem2;

        _item3 = _inputActionMapPlayer.FindAction("Item3");
        _item3.performed += EquipItem3;

        _item4 = _inputActionMapPlayer.FindAction("Item4");
        _item4.performed += EquipItem4;

        _itemNext = _inputActionMapPlayer.FindAction("ItemNext");
        _itemNext.performed += EquipItemNext;

        _itemPrev = _inputActionMapPlayer.FindAction("ItemPrev");
        _itemPrev.performed += EquipItemPrev;
    }
    #endregion

    #region Enable/Disable Input Actions
    private void Enable_InputActions()
    {
        _toggleFlashlight.Enable();
        _toggleXray.Enable();

        _item1.Enable();
        _item2.Enable();
        _item3.Enable();
        _item4.Enable();

        _itemNext.Enable();
        _itemPrev.Enable();
        _interact.Enable();
        _cancel.Enable();
    }

    private void Disable_InputActions()
    {
        _toggleFlashlight.Disable();
        _toggleXray.Disable();

        _item1.Disable();
        _item2.Disable();
        _item3.Disable();
        _item4.Disable();

        _itemNext.Disable();
        _itemPrev.Disable();
        _interact.Disable();
        _cancel.Disable();
    }

    #endregion

    // Various functions for changing user input settings
    #region Input Settings
    public void EnableMenuInput()
    {
        _inputActionMapPlayer.Disable();
        _inputActionMapMenu.Enable();
    }

    public void EnablePlayerInput()
    {
        _inputActionMapPlayer.Enable();
        _inputActionMapMenu.Disable();
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

    // Invokes unity events in response to player input
    #region Input Handler Methods
    private void EndTest(InputAction.CallbackContext context)
    {
        OnEndTest?.Invoke();
    }

    private void Pause(InputAction.CallbackContext context)
    {
        OnPause?.Invoke();
    }

    private void Unpause(InputAction.CallbackContext context)
    {
        OnUnpause?.Invoke();
    }

    private void ToggleXray(InputAction.CallbackContext context)
    {
        OnToggleXray?.Invoke();
    }

    private void ToggleFlashlight(InputAction.CallbackContext context)
    {
        OnToggleFlashlight?.Invoke();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        OnInteract?.Invoke();
    }

    private void InteractRelease(InputAction.CallbackContext context)
    {
        OnInteractRelease?.Invoke();
    }

    private void Cancel(InputAction.CallbackContext context)
    {
        OnCancel?.Invoke();
    }

    private void EquipItem1(InputAction.CallbackContext context)
    {
        OnNumInput?.Invoke(0);
    }

    private void EquipItem2(InputAction.CallbackContext context)
    {
        OnNumInput?.Invoke(1);
    }

    private void EquipItem3(InputAction.CallbackContext context)
    {
        OnNumInput?.Invoke(2);
    }

    private void EquipItem4(InputAction.CallbackContext context)
    {
        OnNumInput?.Invoke(3);
    }

    private void EquipItemNext(InputAction.CallbackContext context)
    {
        OnItemNext?.Invoke();
    }

    private void EquipItemPrev(InputAction.CallbackContext context)
    {
        OnItemPrev?.Invoke();
    }
    #endregion
}
