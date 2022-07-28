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
    [SerializeField] private UnityEvent _onPoweredOn;
    [SerializeField] private UnityEvent _onPoweredOff;

    private bool _isConnectedToPower;

    private void Awake()
    {
        _connectedNode.OnPowerStatusChanged.AddListener(HandlePowerStatusChanged);
    }

    private void OnEnable()
    {
        if (_isSwitchedOn && _connectedNode.CheckPowerStatus())
        {
            _onPoweredOn?.Invoke();
        }

        if (_connectedNode.CheckPowerStatus())
        {
            _isConnectedToPower = true;
        }
    }

    #region Switch/Power on and off Functions
    public void SwitchOn()
    {
        _isSwitchedOn = true;

        if (_isConnectedToPower)
        {
            _onPoweredOn?.Invoke();
        }
        else
        {
            _onPoweredOff?.Invoke();
        }
    }

    public void SwitchOff()
    {
        _isSwitchedOn = false;

        _onPoweredOff?.Invoke();

    }

    public void PowerOn()
    {
        _isConnectedToPower = true;

        if (_isSwitchedOn)
        {
            _onPoweredOn?.Invoke();
        }
        else
        {
            _onPoweredOff?.Invoke();
        }
    }

    public void PowerOff()
    {
        _isConnectedToPower = false;

        _onPoweredOff?.Invoke();

    }

    public void ToggleSwitchStatus()
    {
        if (_isSwitchedOn)
        {
            SwitchOff();
        }
        else
        {
            SwitchOn();
        }
    }

    public void HandlePowerStatusChanged()
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
