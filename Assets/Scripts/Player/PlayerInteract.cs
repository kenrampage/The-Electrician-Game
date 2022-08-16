using UnityEngine;

// Handles raycasting, visibility of cursor objects and interaction with objects implemention IInteractable interface
// Needs further refactoring to add selectable interface and to optimize index checks with the inventory manager
public class PlayerInteract : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 _cursorHiddenPosition;
    [SerializeField] private int _pointerItemIndex = 0;
    [SerializeField] private int _wiringItemIndex = 3;

    private Camera _camera;

    private GameObject _currentTarget;
    private GameObject _cursorObject;

    private InventoryManager _inventoryManager;

    private bool _isOnTarget;


    public void Awake()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
        _camera = Camera.main;
    }

    private void Start()
    {
        InputManager.Instance.OnInteractEvent.AddListener(Interact);
    }

    void FixedUpdate()
    {
        CastRay();
    }

    public void Interact()
    {
        if (_inventoryManager.CheckIfMatchCurrentIndex(_pointerItemIndex) || _inventoryManager.CheckIfMatchCurrentIndex(_wiringItemIndex))
        {
            if (_currentTarget == null) return;

            var interactable = _currentTarget.GetComponent<IInteractable>();

            if (interactable == null) return;

            interactable.Interact();
        }

    }


    private void CastRay()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 5f, _inventoryManager.GetCurrentLayerMask()))
        {
            if (hit.collider.CompareTag(_inventoryManager.GetCurrentTag()))
            {
                _inventoryManager.TurnReticleOff();
                _currentTarget = hit.transform.gameObject;

                SetCursorPosition(hit.point);
            }
            else
            {
                _inventoryManager.TurnReticleOn();
                _currentTarget = null;

                SetCursorLocalPosition(_cursorHiddenPosition);
            }

        }
        else
        {
            _inventoryManager.TurnReticleOn();
            _currentTarget = null;

            SetCursorLocalPosition(_cursorHiddenPosition);

        }

    }

    #region Get/Set Cursor properties
    public Vector3 GetCursorPosition()
    {
        return _cursorObject.transform.position;
    }

    public void SetCursorPosition(Vector3 pos)
    {
        _cursorObject.transform.position = pos;
    }

    public void SetCursorLocalPosition(Vector3 pos)
    {
        _cursorObject.transform.localPosition = pos;
    }

    public void SetCursorObject(GameObject go)
    {
        _cursorObject = go;
    }

    public Quaternion GetCursorRotation()
    {
        return _cursorObject.transform.rotation;
    }
    #endregion

}

