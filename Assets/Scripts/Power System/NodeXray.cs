using UnityEngine;

// Toggles xray marker objects based on player input
public class NodeXray : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _xrayIndicator;

    private bool _isXrayOn = false;

    private void Awake()
    {
        InputManager.Instance.OnToggleXray.AddListener(HandleToggleXrayInput);
    }

    private void TurnXrayOn()
    {
        _xrayIndicator.SetActive(true);
    }

    private void TurnXrayOff()
    {
        _xrayIndicator.SetActive(false);
    }

    private void HandleToggleXrayInput()
    {
        if (_isXrayOn)
        {
            TurnXrayOff();
            _isXrayOn = false;
        }
        else
        {
            TurnXrayOn();
            _isXrayOn = true;
        }
    }
}
