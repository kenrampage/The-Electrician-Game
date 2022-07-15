using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace RampageUtils.UI
{

    // All in one button script handles logic for m+kb and controller inputs plus swapping game objects for visual feedback
    public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISubmitHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler
    {
        private bool _isSubmitting = false;
        private Button _button;

        [Header("Settings")]
        [SerializeField] private float _submitDelay;
        [SerializeField] private bool _isStartResumeButton = false;

        [Header("Events")]
        public UnityEvent OnSubmitEvent;

        [Header("References")]
        [SerializeField] private Button _hiddenButton;
        [SerializeField] private GameObject _textPlain;
        [SerializeField] private GameObject _textSelect;
        [SerializeField] private GameObject _textSubmit;


        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void ButtonSelect()
        {
            _button.Select();
        }

        public void ButtonDeselect()
        {
            _hiddenButton.Select();
        }

        #region Required Interface Methods
        public void OnPointerEnter(PointerEventData eventData)
        {
            ButtonSelect();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //if submit coroutine is running this keeps the button from being deselected too early
            if (_isStartResumeButton && _isSubmitting)
            {

            }
            else
            {
                ButtonDeselect();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(ButtonSubmitCoroutine());

            //Ensure cursor gets locked when starting/resuming gameplay
            if (_isStartResumeButton)
            {
                InputManager.Instance.CursorLockOn();
            }

        }

        public void OnSubmit(BaseEventData eventData)
        {
            StartCoroutine(ButtonSubmitCoroutine());
        }

        public void OnSelect(BaseEventData eventData)
        {
            HandleButtonSelect();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            HandleButtonDeselect();
        }
        #endregion

        #region Button Visuals Handling
        private void TextObjectsOff()
        {
            _textPlain.SetActive(false);
            _textSelect.SetActive(false);
            _textSubmit.SetActive(false);
        }

        private void HandleButtonSelect()
        {
            TextObjectsOff();
            _textSelect.SetActive(true);
        }

        private void HandleButtonDeselect()
        {
            TextObjectsOff();
            _textPlain.SetActive(true);
        }

        private void HandleButtonSubmit()
        {
            TextObjectsOff();
            _textSubmit.SetActive(true);
        }
        #endregion

        private IEnumerator ButtonSubmitCoroutine()
        {
            _isSubmitting = true;

            HandleButtonSubmit();

            yield return new WaitForSecondsRealtime(_submitDelay);

            ButtonDeselect();
            OnSubmitEvent?.Invoke();

            _isSubmitting = false;
        }

    }
}
