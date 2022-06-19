using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class NumInputEvent : UnityEvent<int>
{ }

public class InputManager : Singleton<InputManager>
{
    public NumInputEvent numInputEvent;
    public UnityEvent onItemNext;
    public UnityEvent onItemPrev;

    public UnityEvent onInteract;
    public UnityEvent onInteractRelease;
    public UnityEvent onCancel;
    public UnityEvent onToggleFlashlight;
    public UnityEvent onToggleXray;

    [Header("Input")]
    public InputActionAsset inputActions;
    private InputActionMap inputActionMapInv;
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

    private void Awake()
    {
        CreateEventInstances();
        inputActionMapInv = inputActions.FindActionMap("Inventory");
        inputActionMapPlayer = inputActions.FindActionMap("Player");

        interact = inputActionMapPlayer.FindAction("Interact");
        interact.started += Interact;
        interact.canceled += InteractRelease;

        toggleXray = inputActionMapInv.FindAction("toggleXray");
        toggleXray.performed += ToggleXray;

        toggleFlashlight = inputActionMapInv.FindAction("toggleFlashlight");
        toggleFlashlight.performed += ToggleFlashlight;

        cancel = inputActionMapPlayer.FindAction("Cancel");
        cancel.performed += Cancel;

        item1 = inputActionMapInv.FindAction("Item1");
        item1.performed += EquipItem1;

        item2 = inputActionMapInv.FindAction("Item2");
        item2.performed += EquipItem2;

        item3 = inputActionMapInv.FindAction("Item3");
        item3.performed += EquipItem3;

        item4 = inputActionMapInv.FindAction("Item4");
        item4.performed += EquipItem4;

        itemNext = inputActionMapInv.FindAction("ItemNext");
        itemNext.performed += EquipItemNext;

        itemPrev = inputActionMapInv.FindAction("ItemPrev");
        itemPrev.performed += EquipItemPrev;
    }

    private void Start()
    {

    }

    private void OnEnable()
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

    private void OnDisable()
    {
        toggleXray.Disable();
        toggleFlashlight.Disable();
        item1.Disable();
        item2.Disable();
        item3.Disable();
        item4.Disable();

        itemNext.Disable();
        itemPrev.Disable();
        interact.Disable();
        cancel.Disable();
    }

    private void CreateEventInstances()
    {
        if (numInputEvent == null)
        {
            numInputEvent = new NumInputEvent();
        }
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
}
