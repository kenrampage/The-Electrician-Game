using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InventoryManager : Singleton<InventoryManager>
{
    public InputManager inputManager;



    [Header("Equipment")]
    public float equipDelay;

    // public delegate void ItemChangeAction();
    // public event ItemChangeAction onItemChanged;

    public UnityEvent onItemChanged;

    private int currentIndex;
    public int CurrentIndex
    {
        get { return currentIndex; }
        set
        {
            if (currentIndex != value)
            {
                onItemChanged?.Invoke();
            }
            currentIndex = value;

            print("item changed to index:  " + currentIndex);
        }
    }

    public bool editingCable;
    public GameObject heldCable;


    // public int currentTargetLayerIndex;
    public Animation equipAnim;


    [Header("References")]
    public List<GameObject> markersList;
    public List<GameObject> equipmentList;
    public List<GameObject> reticlesList;
    public List<LayerMask> layerMasksList;
    public List<int> inventoryCount;
    public List<string> tagsList;


    private void Awake()
    {

        ResetEquipment();
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
        inputManager.numInputEvent.AddListener(HandleInput);
        inputManager.onCancel.AddListener(DropCable);


    }



    private void ResetEquipment()
    {

        ChangeEquipment(0);
    }

    // private void SetTargetLayerIndex(int index)
    // {
    //     currentTargetLayerIndex = index + 10;
    // }

    private void ToggleMarkers()
    {
        foreach (var item in markersList)
        {
            item.SetActive(false);
        }

        markersList[CurrentIndex].SetActive(true);
    }

    private void ToggleReticles()
    {
        foreach (var item in reticlesList)
        {
            item.SetActive(false);
        }

        reticlesList[CurrentIndex].SetActive(true);
    }

    private void ChangeEquipment(int equipment)
    {
        foreach (var item in equipmentList)
        {
            item.SetActive(false);
        }

        // SetTargetLayerIndex(equipment);
        CurrentIndex = equipment;
        ToggleMarkers();
        ToggleReticles();
        equipmentList[equipment].SetActive(true);
        equipAnim.Play("Equipment On");
    }

    private IEnumerator ChangeEquipmentAfterDelay(int equipment)
    {
        equipAnim.Play("Equipment Off");
        yield return new WaitForSeconds(equipDelay);
        ChangeEquipment(equipment);

    }

    public bool CheckInventory(int i)
    {
        if (inventoryCount[i] > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncrementInventory(int i)
    {
        inventoryCount[i]++;
    }

    public void DecrementInventory(int i)
    {
        inventoryCount[i]--;
    }

    public bool CheckIfRunningCable()
    {
        if (heldCable == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetHeldCable(GameObject go)
    {
        heldCable = go;
    }
    public void PickupCable(GameObject go)
    {
        editingCable = true;
        SetHeldCable(go);
    }

    public void DropCable()
    {
        editingCable = false;
        heldCable = null;
    }

    public void HandleInput(int i)
    {
        print("received " + i + " from Input Manager");
        StartCoroutine(ChangeEquipmentAfterDelay(i));
    }




}
