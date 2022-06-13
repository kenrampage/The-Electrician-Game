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

    public UnityEvent onInteract;
    public UnityEvent onCancel;

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
    private InputAction item5;
    private InputAction item6;
    private InputAction item7;
    private InputAction item8;
    private InputAction item9;
    private InputAction itemNext;
    private InputAction itemPrev;

    private void Awake()
    {

        inputActionMapInv = inputActions.FindActionMap("Inventory");
        inputActionMapPlayer = inputActions.FindActionMap("Player");

        interact = inputActionMapPlayer.FindAction("Interact");
        interact.performed += Interact;

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

        item5 = inputActionMapInv.FindAction("Item5");
        item5.performed += EquipItem5;

        item6 = inputActionMapInv.FindAction("Item6");
        item6.performed += EquipItem6;

        item7 = inputActionMapInv.FindAction("Item7");
        item7.performed += EquipItem7;

        item8 = inputActionMapInv.FindAction("Item8");
        item8.performed += EquipItem8;

        item9 = inputActionMapInv.FindAction("Item9");
        item9.performed += EquipItem9;

        itemNext = inputActionMapInv.FindAction("ItemNext");
        itemNext.performed += EquipItemNext;

        itemPrev = inputActionMapInv.FindAction("ItemPrev");
        itemPrev.performed += EquipItemPrev;
    }

    private void Start()
    {
        CreateEventInstances();
    }

    private void OnEnable()
    {
        item1.Enable();
        item2.Enable();
        item3.Enable();
        item4.Enable();
        item5.Enable();
        item6.Enable();
        item7.Enable();
        item8.Enable();
        item9.Enable();
        itemNext.Enable();
        itemPrev.Enable();
        interact.Enable();
        cancel.Enable();
    }

    private void OnDisable()
    {
        item1.Disable();
        item2.Disable();
        item3.Disable();
        item4.Disable();
        item5.Disable();
        item6.Disable();
        item7.Disable();
        item8.Disable();
        item9.Disable();
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

    private void Interact(InputAction.CallbackContext context)
    {
        onInteract?.Invoke();
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

    private void EquipItem5(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(4);
    }

    private void EquipItem6(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(5);
    }

    private void EquipItem7(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(6);
    }

    private void EquipItem8(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(7);
    }

    private void EquipItem9(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(8);
    }

    private void EquipItem10(InputAction.CallbackContext context)
    {
        numInputEvent?.Invoke(9);
    }

    private void EquipItemNext(InputAction.CallbackContext context)
    {
        // onItemNext?.Invoke();
    }

    private void EquipItemPrev(InputAction.CallbackContext context)
    {
        // onItemPrev?.Invoke();
    }
}
