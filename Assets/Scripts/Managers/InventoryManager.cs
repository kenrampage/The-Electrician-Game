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

    public PlayerInteract playerInteract;

    public UnityEvent onItemChanged;

    public GameObject flashlightOnObject;
    public GameObject flashlightOffObject;
    public GameObject flashlight;
    public bool isFlashlightOn;

    public int currentIndex;
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

        }
    }

    public bool editingCable;
    public GameObject heldCable;


    // public int currentTargetLayerIndex;
    public Animation equipAnim;


    [Header("References")]
    public List<GameObject> markersList;
    public List<GameObject> cursorList;
    public List<GameObject> reticlesList;
    public List<LayerMask> layerMasksList;
    public List<string> tagsList;
    public List<int> inventoryCount;



    private void Awake()
    {
        playerInteract = FindObjectOfType<PlayerInteract>();
        ResetEquipment();
        ResetFlashlight();
    }

    private void Start()
    {
        inputManager = InputManager.Instance;

        inputManager.numInputEvent.AddListener(HandleNumInput);
        inputManager.onItemNext.AddListener(EquipNextItem);
        inputManager.onItemPrev.AddListener(EquipPrevItem);
        inputManager.onCancel.AddListener(DropCable);
        inputManager.onToggleFlashlight.AddListener(ToggleFlashlight);


    }

    public void ResetFlashlight()
    {
        flashlight.SetActive(false);
        flashlightOffObject.SetActive(true);
        flashlightOnObject.SetActive(false);
    }

    public void ToggleFlashlight()
    {
        print("flashlight toggled");
        if (isFlashlightOn)
        {
            isFlashlightOn = false;
            flashlight.SetActive(false);
            flashlightOffObject.SetActive(true);
            flashlightOnObject.SetActive(false);
        }
        else if (!isFlashlightOn)
        {
            isFlashlightOn = true;
            flashlight.SetActive(true);
            flashlightOffObject.SetActive(false);
            flashlightOnObject.SetActive(true);
        }
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

    private void ChangeEquipment(int itemIndex)
    {
        // foreach (var item in equipmentList)
        // {
        //     item.SetActive(false);
        // }

        // SetTargetLayerIndex(equipment);
        CurrentIndex = itemIndex;
        ToggleMarkers();
        ToggleReticles();
        ChangeCursor();
        playerInteract.cursorObject = cursorList[currentIndex];
        // equipmentList[equipment].SetActive(true);
        // equipAnim.Play("Equipment On");
    }

    // private IEnumerator ChangeEquipmentAfterDelay(int equipment)
    // {
    //     equipAnim.Play("Equipment Off");
    //     yield return new WaitForSeconds(equipDelay);
    //     ChangeEquipment(equipment);

    // }

    // public bool CheckInventory(int i)
    // {
    //     if (inventoryCount[i] > 0)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    // public void IncrementInventory(int i)
    // {
    //     inventoryCount[i]++;
    // }

    // public void DecrementInventory(int i)
    // {
    //     inventoryCount[i]--;
    // }

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

    public void HandleNumInput(int i)
    {
        ChangeEquipment(i);
    }

    public void EquipNextItem()
    {
        if (CurrentIndex == 3)
        {
            CurrentIndex = 0;
        }
        else
        {
            CurrentIndex++;
        }

        ChangeEquipment(CurrentIndex);

    }

    public void EquipPrevItem()
    {
        if (CurrentIndex == 0)
        {
            CurrentIndex = 3;
        }
        else
        {
            CurrentIndex--;
        }

        ChangeEquipment(CurrentIndex);
    }

    public void ChangeCursor()
    {
        foreach (var item in cursorList)
        {
            item.SetActive(false);
        }

        cursorList[currentIndex].SetActive(true);
    }
    




}
