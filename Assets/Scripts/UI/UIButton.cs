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

        [Header("Events")]
        public UnityEvent OnPointerDownEvent;
        public UnityEvent OnSubmitEvent;

        [Header("Settings")]
        [SerializeField] private float _submitDelay;

        [Header("References")]
        [SerializeField] private Button _hiddenButton;
        [SerializeField] private GameObject _textPlain;
        [SerializeField] private GameObject _textSelect;
        [SerializeField] private GameObject _textSubmit;

        [Header("Audio")]
        [SerializeField] private FMODPlayOneShot _sfxSelect;
        [SerializeField] private FMODPlayOneShot _sfxSubmit;

        private bool _isSelected = false;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void ButtonSelect()
        {
            _button.Select();
            _isSelected = true;
        }

        public void ButtonDeselect()
        {
            _hiddenButton.Select();
            _isSelected = false;
        }

        private void OnDisable()
        {
            HandleButtonDeselect();
        }

        #region Required Interface Methods
        public void OnPointerEnter(PointerEventData eventData)
        {
            ButtonSelect();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ButtonDeselect();
            StopCoroutine(ButtonSubmitCoroutine());
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(ButtonSubmitCoroutine());
            OnPointerDownEvent?.Invoke();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            StartCoroutine(ButtonSubmitCoroutine());
        }

        public void OnSelect(BaseEventData eventData)
        {
            _isSelected = true;
            HandleButtonSelect();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _isSelected = false;
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
            _sfxSelect.Play();
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
            _sfxSubmit.Play();
        }

        private void HandleButtonAfterSubmit()
        {
            TextObjectsOff();
            _textSelect.SetActive(true);
        }
        #endregion

        #region Coroutines
        private IEnumerator ButtonSubmitCoroutine()
        {
            HandleButtonSubmit();

            yield return new WaitForSecondsRealtime(_submitDelay);

            if (_isSelected)
            {
                HandleButtonAfterSubmit();
            }
            else
            {
                ButtonDeselect();
            }

            OnSubmitEvent?.Invoke();
        }
        #endregion

    }
}
