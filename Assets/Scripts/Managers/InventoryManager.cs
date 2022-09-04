using System.Collections.Generic;
using UnityEngine;
using RampageUtils;

// Manages equipped items, held cable, related UI markers
// Needs to be refactored further breaking out UI functionality
public class InventoryManager : Singleton<InventoryManager>
{
    [Header("References")]
    [SerializeField] private GameObject _reticle;

    [Header("Audio")]
    [SerializeField] private FMODPlayOneShot _sfxItemChange;

    [Header("Equipment Lists")]
    [SerializeField] private List<ToggleTargetObjects> _uiMarkersList;
    [SerializeField] private List<GameObject> _cursorList;
    [SerializeField] private List<LayerMask> _layerMasksList;
    [SerializeField] private List<string> _tagsList;

    private PlayerInteract _playerInteract;
    private GameObject _heldCable;

    private int _currentIndex;
    private bool _isHoldingCable;

    private void Awake()
    {
        _playerInteract = FindObjectOfType<PlayerInteract>();
        ResetEquipment();
    }

    private void Start()
    {
        var inputManager = InputManager.Instance;

        inputManager.OnItemNextEvent.AddListener(HandleItemNextInput);
        inputManager.OnItemPrevEvent.AddListener(HandleItemPrevInput);

    }

    #region Handle Player Input
    public void HandleItemNextInput()
    {
        var newIndex = _currentIndex + 1;
        if (newIndex > _cursorList.Count - 1)
        {
            newIndex = 0;
        }

        ChangeEquipment(newIndex);
        _sfxItemChange.Play();
    }

    public void HandleItemPrevInput()
    {
        var newIndex = _currentIndex - 1;
        if (newIndex < 0)
        {
            newIndex = _cursorList.Count - 1;
        }

        ChangeEquipment(newIndex);
        _sfxItemChange.Play();
    }

    #endregion

    #region Changing Equipped Items
    private void ChangeEquipment(int itemIndex)
    {
        if (CheckIfHoldingCable())
        {
            DestroyHeldCable();
        }

        _currentIndex = itemIndex;

        ToggleMarkers();
        ChangeCursor();
        _playerInteract.SetCursorObject(_cursorList[_currentIndex]);
    }

    private void ResetEquipment()
    {
        ChangeEquipment(0);
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

    public string GetCurrentTag()
    {
        return _tagsList[_currentIndex];
    }

    #endregion

    #region UI
    // Changes the markers indicating which item is equipped in the game UI
    private void ToggleMarkers()
    {
        foreach (var item in _uiMarkersList)
        {
            item.SetInactive();
        }

        _uiMarkersList[_currentIndex].SetActive();
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
