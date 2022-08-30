using UnityEngine;
using UnityEngine.InputSystem;

// Repurposed script from StarterAssetsPackage. https://assetstore.unity.com/packages/essentials/starter-assets-first-person-character-controller-196525 
// Removed ground checks and jump functionality from original script
[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Settings Scriptable Object")]
    [SerializeField] private SOSettings _settings;

    [Header("Player Settings")]
    [SerializeField] private float _moveSpeed = 4.0f;
    [SerializeField] private float _sprintSpeed = 6.0f;
    [SerializeField] private float _lookSensitivity = 1.0f;
    [SerializeField] private float _moveSpeedChangeRate = 10.0f;
    [SerializeField] private float _gravityPower = -.5f;

    [Header("Camera Settings")]
    [SerializeField] private GameObject _cinemachineCameraTarget;
    [SerializeField] private float _topClamp = 90.0f;
    [SerializeField] private float _bottomClamp = -90.0f;

    // cinemachine
    private float _cinemachineTargetPitch;

    // player
    private float _currentMoveSpeed;
    private float _rotationVelocity;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;

    // References
    private PlayerInput _playerInput;
    private CharacterController _controller;
    private InputManager _inputManager;
    private GameObject _mainCamera;

    // Input
    private const float _inputThreshold = 0.01f;

    private void Awake()
    {
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        _settings.OnLookSensitivityChanged.AddListener(HandleLookSensitivityChanged);
    }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
        Gravity();
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    private void HandleLookSensitivityChanged()
    {
        _lookSensitivity = _settings.GetLookSensitivity();
    }

    private void CameraRotation()
    {
        // if there is an input
        if (_inputManager.LookInput.sqrMagnitude >= _inputThreshold)
        {
            //Don't multiply mouse input by Time.deltaTime
            float deltaTimeMultiplier = _inputManager.CurrentInputDeviceType == InputDeviceType.MKB ? 1.0f : Time.deltaTime;

            _cinemachineTargetPitch += _inputManager.LookInput.y * _lookSensitivity * deltaTimeMultiplier;
            _rotationVelocity = _inputManager.LookInput.x * _lookSensitivity * deltaTimeMultiplier;

            // clamp our pitch rotation
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _bottomClamp, _topClamp);

            // Update Cinemachine camera target pitch
            _cinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            transform.Rotate(Vector3.up * _rotationVelocity);
        }
    }

    private void Move()
    {
        // set target speed based on move speed, sprint speed and if sprint is pressed
        float targetSpeed = _inputManager.SprintInput ? _sprintSpeed : _moveSpeed;

        // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

        // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is no input, set the target speed to 0
        if (_inputManager.MoveInput == Vector2.zero) targetSpeed = 0.0f;

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = _inputManager.IsAnalogInput ? _inputManager.MoveInput.magnitude : 1f;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _currentMoveSpeed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * _moveSpeedChangeRate);

            // round speed to 3 decimal places
            _currentMoveSpeed = Mathf.Round(_currentMoveSpeed * 1000f) / 1000f;
        }
        else
        {
            _currentMoveSpeed = targetSpeed;
        }

        // normalise input direction
        Vector3 inputDirection = new Vector3(_inputManager.MoveInput.x, 0.0f, _inputManager.MoveInput.y).normalized;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (_inputManager.MoveInput != Vector2.zero)
        {
            // move
            inputDirection = transform.right * _inputManager.MoveInput.x + transform.forward * _inputManager.MoveInput.y;
        }

        // move the player
        _controller.Move(inputDirection.normalized * (_currentMoveSpeed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
    }

    private void Gravity()
    {
        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += _gravityPower * Time.deltaTime;
        }
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

}
