using UnityEngine;
using UnityEngine.UI;

namespace RampageUtils.UI
{
    // Each game menu requires a hidden button to be selected by default to ensure controller & m+kb input compatability
    public class UIButtonHidden : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _isSelectedOnEnable = true;

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
            }
        }

        public void ButtonSelect()
        {
            _button.Select();
        }

    }
}
