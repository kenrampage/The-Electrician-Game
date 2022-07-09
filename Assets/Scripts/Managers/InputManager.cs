using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class NumInputEvent : UnityEvent<int>
{ }

public class InputManager : Singleton<InputManager>
{
    #region UnityEvents
    [HideInInspector] public NumInputEvent numInputEvent;
    [HideInInspector] public UnityEvent onItemNext;
    [HideInInspector] public UnityEvent onItemPrev;
    [HideInInspector] public UnityEvent onInteract;
    [HideInInspector] public UnityEvent onInteractRelease;
    [HideInInspector] public UnityEvent onCancel;
    [HideInInspector] public UnityEvent onToggleFlashlight;
    [HideInInspector] public UnityEvent onToggleXray;
    public UnityEvent onPause;
    public UnityEvent onUnpause;
    public UnityEvent onEndTest;
    #endregion

    #region InputAction Variables
    [Header("Input")]
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private string currentInputActionMap = null;
    private InputActionMap inputActionMapMenu;
    private InputActionMap inputActionMapPlayer;

    private InputAction interact;
    private InputAction cancel;
    private InputAction item1;
    private InputAction item2;
    private InputAction item3;
    private InputAction item4;
    private InputAction itemNext;
    private InputAction itemPrev;
    private InputAction toggleFlashlight;
    private InputAction toggleXray;
    private InputAction pause;
    private InputAction unpause;
    private InputAction endTest;
    #endregion

    #region Default Methods
    private void Awake()
    {
        CreateEventInstances();
        GetInputActionReferences();
    }

    private void OnEnable()
    {
        EnableInputActions();
    }

    private void OnDisable()
    {
        DisableInputActions();
    }
    #endregion

    private void CreateEventInstances()
    {
        if (numInputEvent == null)
        {
            numInputEvent = new NumInputEvent();
        }
    }

    private void GetInputActionReferences()
    {
        inputActionMapMenu = inputActions.FindActionMap("Menu");
        inputActionMapPlayer = inputActions.FindActionMap("Player");

        endTest = inputActionMapPlayer.FindAction("EndTest");
        endTest.started += EndTest;

        pause = inputActionMapPlayer.FindAction("Pause");
        pause.started += Pause;

        unpause = inputActionMapMenu.FindAction("Unpause");
        unpause.started += Unpause;

        interact = inputActionMapPlayer.FindAction("Interact");
        interact.started += Interact;
        interact.canceled += InteractRelease;

        toggleXray = inputActionMapPlayer.FindAction("toggleXray");
        toggleXray.performed += ToggleXray;

        toggleFlashlight = inputActionMapPlayer.FindAction("toggleFlashlight");
        toggleFlashlight.performed += ToggleFlashlight;

        cancel = inputActionMapPlayer.FindAction("Cancel");
        cancel.performed += Cancel;

        item1 = inputActionMapPlayer.FindAction("Item1");
        item1.performed += EquipItem1;

        item2 = inputActionMapPlayer.FindAction("Item2");
        item2.performed += EquipItem2;

        item3 = inputActionMapPlayer.FindAction("Item3");
        item3.performed += EquipItem3;

        item4 = inputActionMapPlayer.FindAction("Item4");
        item4.performed += EquipItem4;

        itemNext = inputActionMapPlayer.FindAction("ItemNext");
        itemNext.performed += EquipItemNext;

        itemPrev = inputActionMapPlayer.FindAction("ItemPrev");
        itemPrev.performed += EquipItemPrev;
    }

    #region Enable/Disable Input Actions
    private void EnableInputActions()
    {
        toggleFlashlight.Enable();
        toggleXray.Enable();

        item1.Enable();
        item2.Enable();
        item3.Enable();
        item4.Enable();

        itemNext.Enable();
        itemPrev.Enable();
        interact.Enable();
        cancel.Enable();
    }

    private void DisableInputActions()
    {
        toggleFlashlight.Disable();
        toggleXray.Disable();

        item1.Disable();
        item2.Disable();
        item3.Disable();
        item4.Disable();

        itemNext.Disable();
        itemPrev.Disable();
        interact.Disable();
        cancel.Disable();
    }

    #endregion

    #region Input Settings
    public void EnableMenuInput()
    {
        inputActionMapPlayer.Disable();
        inputActionMapMenu.Enable();
        currentInputActionMap = "Menu";
    }

    public void EnablePlayerInput()
    {
        inputActionMapPlayer.Enable();
        inputActionMapMenu.Disable();
        currentInputActionMap = "Player";
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

    #region Input Callback Methods

    private void EndTest(InputAction.CallbackContext context)
    {
        onEndTest?.Invoke();
    }

    private void Pause(InputAction.CallbackContext context)
    {
        onPause?.Invoke();
    }

    private void Unpause(InputAction.CallbackContext context)
    {
        onUnpause?.Invoke();
    }

    private void ToggleXray(InputAction.CallbackContext context)
    {
        onToggleXray?.Invoke();
    }

    private void ToggleFlashlight(InputAction.CallbackContext context)
    {
        onToggleFlashlight?.Invoke();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        onInteract?.Invoke();
    }

    private void InteractRelease(InputAction.CallbackContext context)
    {
        onInteractRelease?.Invoke();
    }

    private void Cancel(InputAction.CallbackContext context)
    {
        onCancel?.Invoke();
    }

    private void EquipItem1(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(0);
    }

    private void EquipItem2(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(1);
    }

    private void EquipItem3(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(2);
    }

    private void EquipItem4(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(3);
    }

    private void EquipItemNext(InputAction.CallbackContext context)
    {
        onItemNext?.Invoke();
    }

    private void EquipItemPrev(InputAction.CallbackContext context)
    {
        onItemPrev?.Invoke();
    }
    #endregion
}
