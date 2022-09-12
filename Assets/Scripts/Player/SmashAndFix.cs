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

    [Header("Particle Settings")]
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Vector3 _particlePositionOffset;

    [Header("Cursor Animation")]
    [SerializeField] private Animation _smashAnim;
    [SerializeField] private Animation _fixAnim;

    [Header("Audio")]
    [SerializeField] private ObjectPooler _sfxSmashPool;
    [SerializeField] private ObjectPooler _sfxFixPool;

    private InventoryManager _inventoryManager;
    private PlayerInteract _playerInteract;

    private bool _isAbleToInteract = true;

    private void Start()
    {
        _playerInteract = GetComponent<PlayerInteract>();
        _inventoryManager = InventoryManager.Instance;
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

            // Play Cursor Animation
            _smashAnim.Play();

            // Play Particle
            Instantiate<ParticleSystem>(_particleSystem, _playerInteract.GetCursorPosition() + _particlePositionOffset, _playerInteract.GetCursorRotation());

            // Play Sound
            _sfxSmashPool.RetrieveObject(_playerInteract.GetCursorPosition(), _playerInteract.GetCursorRotation());

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

            // Play Cursor Animation
            _fixAnim.Play();

            // Play Particle
            Instantiate<ParticleSystem>(_particleSystem, _playerInteract.GetCursorPosition() + _particlePositionOffset, _playerInteract.GetCursorRotation());

            // Play Sound
            _sfxFixPool.RetrieveObject(_playerInteract.GetCursorPosition(), _playerInteract.GetCursorRotation());

            // wait
            yield return new WaitForSecondsRealtime(_interactDuration);

            // Reset position
            _fixerObject.transform.position = PlayerHoldPosition.Position;
            _fixerObject.SetActive(false);

            // Re-enable interaction
            _isAbleToInteract = true;
        }
    }

    public void StartSmash()
    {
        StartCoroutine(Smash());
    }

    public void StartFix()
    {
        StartCoroutine(Fix());
    }

}
