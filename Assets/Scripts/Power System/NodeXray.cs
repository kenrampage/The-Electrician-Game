using UnityEngine;

// Toggles xray marker objects based on player input
public class NodeXray : MonoBehaviour
{
    [SerializeField] private GameObject _xrayIndicator;
    private bool _isXrayOn;

    private void Awake()
    {
        InputManager.Instance.onToggleXray.AddListener(HandleToggleXrayInput);

        if (_isXrayOn)
        {
            TurnXrayOn();
        }
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
