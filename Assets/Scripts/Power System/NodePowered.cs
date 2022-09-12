using UnityEngine;
using UnityEngine.Events;

// Works as a power switch for interactable objects in the scene
public class NodePowered : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] private Node _connectedNode;

    [Header("Settings")]
    [SerializeField] private bool _isSwitchedOn;

    [Header("Events")]
    [SerializeField] private UnityEvent _onSwitchedOn;
    [SerializeField] private UnityEvent _onSwitchedOff;

    [SerializeField] private UnityEvent _onPoweredOn;
    [SerializeField] private UnityEvent _onPoweredOff;

    [SerializeField] private bool _isConnectedToPower;

    private void Awake()
    {
        _connectedNode.OnPowerStatusChanged.AddListener(HandlePowerStatusChanged);
    }

    private void OnEnable()
    {
        CheckPowerStatus();

        if (_isSwitchedOn && _isConnectedToPower)
        {
            _onPoweredOn?.Invoke();
        }
        
    }

    #region Switch/Power on and off Functions
    public void SwitchOn()
    {
        _isSwitchedOn = true;

        _onSwitchedOn?.Invoke();

        if (_isConnectedToPower)
        {
            _onPoweredOn?.Invoke();
        }

    }

    public void SwitchOff()
    {
        _isSwitchedOn = false;

        _onSwitchedOff?.Invoke();

        if (_isConnectedToPower)
        {
            _onPoweredOff?.Invoke();
        }

    }

    public void SwitchOffNoEvents()
    {
        _isSwitchedOn = false;
    }

    public void PowerOn()
    {
        _isConnectedToPower = true;
    }

    public void PowerOff()
    {
        _isConnectedToPower = false;
    }

    public void ToggleSwitchStatus()
    {
        CheckPowerStatus();

        if (_isSwitchedOn)
        {
            SwitchOff();
        }
        else
        {
            SwitchOn();
        }
    }

    public void CheckPowerStatus()
    {
        if (_connectedNode.CheckPowerStatus())
        {
            PowerOn();
        }
        else
        {
            PowerOff();
        }
    }

    public void HandlePowerStatusChanged()
    {
        CheckPowerStatus();
        if (_isSwitchedOn)
        {
            _onPoweredOn?.Invoke();
        }
    }
    #endregion

    #region IInteractable functions
    public void Interact()
    {
        ToggleSwitchStatus();
    }

    public void Cancel()
    {

    }
    #endregion

}
