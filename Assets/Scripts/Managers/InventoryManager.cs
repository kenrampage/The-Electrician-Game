using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InventoryManager : Singleton<InventoryManager>
{

    [Header("Input")]
    public InputActionAsset inputActions;
    private InputActionMap inputActionMap;

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


    [Header("Equipment")]
    public float equipDelay;
    public int currentIndex;
    public Animation equipAnim;
    public int item7Count;
    public int item8Count;
    public int item9Count;

    [Header("References")]
    public List<GameObject> markersList;
    public List<GameObject> equipmentList;
    public List<LayerMask> layerMasksList;

    


    protected override void Awake()
    {
        base.Awake();
        inputActionMap = inputActions.FindActionMap("Inventory");

        item1 = inputActionMap.FindAction("Item1");
        item1.performed += EquipItem1;

        item2 = inputActionMap.FindAction("Item2");
        item2.performed += EquipItem2;

        item3 = inputActionMap.FindAction("Item3");
        item3.performed += EquipItem3;

        item4 = inputActionMap.FindAction("Item4");
        item4.performed += EquipItem4;

        item5 = inputActionMap.FindAction("Item5");
        item5.performed += EquipItem5;

        item6 = inputActionMap.FindAction("Item6");
        item6.performed += EquipItem6;

        item7 = inputActionMap.FindAction("Item7");
        item7.performed += EquipItem7;

        item8 = inputActionMap.FindAction("Item8");
        item8.performed += EquipItem8;

        item9 = inputActionMap.FindAction("Item9");
        item9.performed += EquipItem9;

        itemNext = inputActionMap.FindAction("ItemNext");
        itemNext.performed += EquipItemNext;

        itemPrev = inputActionMap.FindAction("ItemPrev");
        itemPrev.performed += EquipItemPrev;
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
    }

    private void ResetEquipment()
    {
        ToggleMarkers(0);
        ChangeEquipment(0);
    }

    private void ToggleMarkers(int marker)
    {
        foreach (var item in markersList)
        {
            item.SetActive(false);
        }

        currentIndex = marker;
        markersList[marker].SetActive(true);
    }

    private void ChangeEquipment(int equipment)
    {
        foreach (var item in equipmentList)
        {
            item.SetActive(false);
        }

        equipmentList[equipment].SetActive(true);
        equipAnim.Play("Equipment On");
    }

    private IEnumerator ChangeEquipmentAfterDelay(int equipment)
    {
        equipAnim.Play("Equipment Off");
        yield return new WaitForSeconds(equipDelay);
        ChangeEquipment(equipment);

    }

    private void EquipItem1(InputAction.CallbackContext context)
    {
        // onItem1?.Invoke();
        ToggleMarkers(0);
        StartCoroutine(ChangeEquipmentAfterDelay(0));
    }

    private void EquipItem2(InputAction.CallbackContext context)
    {
        // onItem2?.Invoke();
        ToggleMarkers(1);
        StartCoroutine(ChangeEquipmentAfterDelay(1));
    }

    private void EquipItem3(InputAction.CallbackContext context)
    {
        // onItem3?.Invoke();
        ToggleMarkers(2);
        StartCoroutine(ChangeEquipmentAfterDelay(2));
    }

    private void EquipItem4(InputAction.CallbackContext context)
    {
        // onItem4?.Invoke();
        ToggleMarkers(3);
        StartCoroutine(ChangeEquipmentAfterDelay(3));
    }

    private void EquipItem5(InputAction.CallbackContext context)
    {
        // onItem5?.Invoke();
        ToggleMarkers(4);
        StartCoroutine(ChangeEquipmentAfterDelay(4));
    }

    private void EquipItem6(InputAction.CallbackContext context)
    {
        // onItem6?.Invoke();
        ToggleMarkers(5);
        StartCoroutine(ChangeEquipmentAfterDelay(5));
    }

    private void EquipItem7(InputAction.CallbackContext context)
    {
        // onItem7?.Invoke();
        ToggleMarkers(6);
        StartCoroutine(ChangeEquipmentAfterDelay(6));
    }

    private void EquipItem8(InputAction.CallbackContext context)
    {
        // onItem8?.Invoke();
        ToggleMarkers(7);
        StartCoroutine(ChangeEquipmentAfterDelay(7));
    }

    private void EquipItem9(InputAction.CallbackContext context)
    {
        // onItem9?.Invoke();
        ToggleMarkers(8);
        StartCoroutine(ChangeEquipmentAfterDelay(8));
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
