using UnityEngine;

// Toggles xray marker objects based on player input
public class UINodeXray : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _xrayIndicator;

    [Header("Audio")]
    [SerializeField] private FMODPlayOneShot _sfxXrayToggle;

    private bool _isXrayOn = false;

    private void Awake()
    {
        InputManager.Instance.OnToggleXrayEvent.AddListener(HandleToggleXrayInput);
    }

    private void TurnXrayOn()
    {
        _xrayIndicator.SetActive(true);
        _sfxXrayToggle.Play();
    }

    private void TurnXrayOff()
    {
        _xrayIndicator.SetActive(false);
        _sfxXrayToggle.Play();
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
