using UnityEngine;

// Toggles xray marker objects based on player input
public class NodeXray : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _xrayIndicators;
    private bool _isXrayOn = false;

    private void Awake()
    {
        InputManager.Instance.OnToggleXrayEvent.AddListener(HandleToggleXrayInput);
    }

    private void TurnXrayOn()
    {
        foreach (var item in _xrayIndicators)
        {
            item.SetActive(true);
        }
        // _xrayIndicator.SetActive(true);
    }

    private void TurnXrayOff()
    {
        foreach (var item in _xrayIndicators)
        {
            item.SetActive(false);
        }

        // _xrayIndicator.SetActive(false);
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
