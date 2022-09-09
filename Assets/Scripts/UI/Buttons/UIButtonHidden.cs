using UnityEngine;
using UnityEngine.UI;

namespace RampageUtils.UI
{
    // Each game menu requires a hidden button to be selected by default to ensure controller & m+kb input compatability
    public class UIButtonHidden : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _isSelectedOnEnable = true;
        [SerializeField] private bool _isSelectedWhenInputDeviceChanged;

        private InputManager _inputManager;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();


        }

        private void OnEnable()
        {
            if (_isSelectedOnEnable)
            {
                ButtonSelect();
                print(gameObject.name + " selected on Enable!");
            }

            _inputManager = InputManager.Instance;
            _inputManager.OnInputDeviceTypeChanged.AddListener(HandleDeviceTypeChanged);

        }

        public void ButtonSelect()
        {
            _button.Select();
        }

        private void HandleDeviceTypeChanged()
        {
            if (_isSelectedWhenInputDeviceChanged)
            {
                ButtonSelect();
                print(gameObject.name + " selected on Device Change!");
            }
        }

    }
}
