using UnityEngine;

// Handles raycasting, visibility of cursor objects and interaction with objects implemention IInteractable interface
// Needs further refactoring to add selectable interface and to optimize index checks with the inventory manager
public class PlayerInteract : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 _cursorHiddenPosition;

    [Header("Cursor Animation")]
    [SerializeField] private Animation _handAnim;
    [SerializeField] private Animation _wireAnim;

    [Header("References")]
    [SerializeField] private Camera _camera;
    [SerializeField] private SmashAndFix _smashAndFix;

    private GameObject _currentTarget;
    private GameObject _cursorObject;

    private InventoryManager _inventoryManager;

    private bool _isOnTarget;


    public void Awake()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
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
        switch (_inventoryManager.GetCurrentTargetType())
        {
            case Equipment.Type.INTERACTABLE:
                InteractWithInteractable();
                break;

            case Equipment.Type.WALLON:
                InteractWithWallOn();
                break;

            case Equipment.Type.WALLOFF:
                InteractWithWallOff();
                break;

            case Equipment.Type.WIRABLE:
                InteractWithWirable();
                break;

            default:
                break;
        }

    }

    private void InteractWithInteractable()
    {
        if (_currentTarget == null) return;

        var iInteractable = _currentTarget.GetComponent<IInteractable>();

        if (iInteractable == null) return;

        _handAnim.Play();
        iInteractable.Interact();
    }

    private void InteractWithWallOn()
    {
        if (_currentTarget == null) return;
        _smashAndFix.StartSmash();
    }

    private void InteractWithWallOff()
    {
        if (_currentTarget == null) return;
        _smashAndFix.StartFix();
    }

    private void InteractWithWirable()
    {
        if (_currentTarget == null) return;

        var iInteractable = _currentTarget.GetComponent<IInteractable>();

        if (iInteractable == null) return;

        _wireAnim.Play();
        iInteractable.Interact();

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

