using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages equipped items, held cable, toggling flashlight and related UI markers
// Needs to be refactored further breaking out flashlight and UI functionality at least
public class InventoryManager : Singleton<InventoryManager>
{
    private PlayerInteract _playerInteract;
    private GameObject _heldCable;

    private int _currentIndex;
    private bool _isHoldingCable;
    private bool _isFlashlightOn;

    [Header("References")]
    [SerializeField] private GameObject _flashlightObject;
    [SerializeField] private GameObject _reticle;

    [Header("Equipment Lists")]
    [SerializeField] private List<GameObject> _uiMarkersList;
    [SerializeField] private List<GameObject> _cursorList;
    [SerializeField] private List<LayerMask> _layerMasksList;

    [Header("UI References")]
    [SerializeField] private GameObject _flashlightOnMarker;
    [SerializeField] private GameObject _flashlightOffMarker;

    private void Awake()
    {
        _playerInteract = FindObjectOfType<PlayerInteract>();
        ResetEquipment();
        ResetFlashlight();
    }

    private void Start()
    {
        var inputManager = InputManager.Instance;

        inputManager.OnNumInput.AddListener(HandleNumInput);
        inputManager.OnToggleFlashlight.AddListener(ToggleFlashlight);

    }

    #region Handle Player Input
    public void HandleNumInput(int i)
    {
        ChangeEquipment(i);
    }
    #endregion

    #region Changing Equipped Items
    private void ChangeEquipment(int itemIndex)
    {
        if (itemIndex != _currentIndex)
        {
            _currentIndex = itemIndex;
        }

        ToggleMarkers();
        ChangeCursor();
        _playerInteract.cursorObject = _cursorList[_currentIndex];
    }

    private void ResetEquipment()
    {
        ChangeEquipment(0);
    }

    public void ToggleFlashlight()
    {
        if (_isFlashlightOn)
        {
            _isFlashlightOn = false;
            _flashlightObject.SetActive(false);
            _flashlightOffMarker.SetActive(true);
            _flashlightOnMarker.SetActive(false);
        }
        else if (!_isFlashlightOn)
        {
            _isFlashlightOn = true;
            _flashlightObject.SetActive(true);
            _flashlightOffMarker.SetActive(false);
            _flashlightOnMarker.SetActive(true);
        }
    }

    public void ResetFlashlight()
    {
        _flashlightObject.SetActive(false);
        _flashlightOffMarker.SetActive(true);
        _flashlightOnMarker.SetActive(false);
    }
    #endregion

    #region Cable Related Functions
    public void DestroyHeldCable()
    {
        DestroyImmediate(_heldCable.gameObject);
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

    public void SetHeldCable(GameObject go)
    {
        _heldCable = go;
    }

    public GameObject GetHeldCable()
    {
        return _heldCable;
    }

    public bool CheckIfCableMatches(GameObject go)
    {
        if (_heldCable == go)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PickupCable(GameObject go)
    {
        _isHoldingCable = true;
        SetHeldCable(go);
    }

    public void DropCable()
    {
        _isHoldingCable = false;
        _heldCable = null;
    }
    #endregion

    #region Get and Check functions
    // Check if currently equipped item's index matches the parameter
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

    public int GetCurrentIndex()
    {
        return _currentIndex;
    }

    public LayerMask GetCurrentLayerMask()
    {
        return _layerMasksList[_currentIndex];
    }
    #endregion

    #region UI
    // Changes the markers indicating which item is equipped in the game UI
    private void ToggleMarkers()
    {
        foreach (var item in _uiMarkersList)
        {
            item.SetActive(false);
        }

        _uiMarkersList[_currentIndex].SetActive(true);
    }

    public void ChangeCursor()
    {
        foreach (var item in _cursorList)
        {
            item.SetActive(false);
        }

        _cursorList[_currentIndex].SetActive(true);
    }

    public void TurnReticleOff()
    {
        _reticle.SetActive(false);
    }

    public void TurnReticleOn()
    {
        _reticle.SetActive(true);
    }
    #endregion

}
