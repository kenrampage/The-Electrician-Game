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

    public PlayerInteract playerInteract;

    public UnityEvent onItemChanged;

    public GameObject flashlightOnObject;
    public GameObject flashlightOffObject;
    public GameObject flashlight;
    public bool isFlashlightOn;

    private int _currentIndex;
    public int CurrentIndex
    {
        get { return _currentIndex; }
        set
        {
            if (_currentIndex != value)
            {
                onItemChanged?.Invoke();
            }
            _currentIndex = value;

        }
    }

    public bool _isHoldingCable;
    public GameObject heldCable;

    [Header("References")]
    public List<GameObject> markersList;
    public List<GameObject> cursorList;
    public GameObject reticle;
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

    private void ToggleMarkers()
    {
        foreach (var item in markersList)
        {
            item.SetActive(false);
        }

        markersList[CurrentIndex].SetActive(true);
    }

    private void ChangeEquipment(int itemIndex)
    {
        CurrentIndex = itemIndex;
        ToggleMarkers();
        ChangeCursor();
        playerInteract.cursorObject = cursorList[_currentIndex];
    }

    public void SetHeldCable(GameObject go)
    {
        heldCable = go;
    }
    public void PickupCable(GameObject go)
    {
        _isHoldingCable = true;
        SetHeldCable(go);
    }

    public void DropCable()
    {
        _isHoldingCable = false;
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

        cursorList[_currentIndex].SetActive(true);
    }


    public void TurnReticleOff()
    {
        reticle.SetActive(false);
    }

    public void TurnReticleOn()
    {
        reticle.SetActive(true);
    }

    public void DestroyHeldCable()
    {
        DestroyImmediate(heldCable.gameObject);
        DropCable();
    }

    public bool CheckIfHoldingCable()
    {
        if (_isHoldingCable)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckIfMatchCurrentIndex(int i)
    {
        if (_currentIndex == i)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
