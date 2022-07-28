using System.Collections;
using UnityEngine;

// Sets the position of the smasher/fixer object to the position of the players cursor which interacts with WallFragment script
public class SmashAndFix : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _smasherObject;
    [SerializeField] private GameObject _fixerObject;

    [Header("Settings")]
    [SerializeField] private float _interactDuration = .1f;
    [SerializeField] private int _smashItemIndex = 1;
    [SerializeField] private int _fixItemIndex = 2;

    private InventoryManager _inventoryManager;
    private PlayerInteract _playerInteract;

    private bool _isAbleToInteract = true;

    private void Start()
    {
        _playerInteract = GetComponent<PlayerInteract>();
        _inventoryManager = InventoryManager.Instance;

        InputManager.Instance.OnInteractEvent.AddListener(Interact);
    }


    public IEnumerator Smash()
    {
        // Check if able to interact
        if (_isAbleToInteract)
        {
            // Disable interaction
            _isAbleToInteract = false;

            // Turns on object and sets its position to the position of the player's cursor
            _smasherObject.SetActive(true);
            _smasherObject.transform.position = _playerInteract.GetCursorPosition();

            // wait
            yield return new WaitForSecondsRealtime(_interactDuration);

            // Reset position
            _smasherObject.transform.position = PlayerHoldPosition.Position;
            _smasherObject.SetActive(false);

            // Re-enable interaction
            _isAbleToInteract = true;
        }
    }

    public IEnumerator Fix()
    {
        // Check if able to interact
        if (_isAbleToInteract)
        {
            // Disable interaction
            _isAbleToInteract = false;

            // Turns on object and sets its position to the position of the player's cursor
            _fixerObject.SetActive(true);
            _fixerObject.transform.position = _playerInteract.GetCursorPosition();

            // wait
            yield return new WaitForSecondsRealtime(_interactDuration);

            // Reset position
            _fixerObject.transform.position = PlayerHoldPosition.Position;
            _fixerObject.SetActive(false);

            // Re-enable interaction
            _isAbleToInteract = true;
        }
    }

    // Handle Player Input
    public void Interact()
    {
        if (_inventoryManager.CheckIfMatchCurrentIndex(_smashItemIndex))
        {
            StartCoroutine(Smash());
        }
        else if (_inventoryManager.CheckIfMatchCurrentIndex(_fixItemIndex))
        {
            StartCoroutine(Fix());
        }
    }

}
