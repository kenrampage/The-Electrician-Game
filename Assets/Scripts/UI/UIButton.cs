using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISubmitHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler
{
    [SerializeField] private Button hiddenButton;

    private Button button;
    [SerializeField] private float submitDelay;
    [SerializeField] private bool startResumeButton = false;
    private bool submitting = false;

    public UnityEvent onSubmit;

    [Header("Text Objects")]
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject textSelect;
    [SerializeField] private GameObject textSubmit;


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void ButtonSelect()
    {
        button.Select();
    }

    public void ButtonDeselect()
    {
        hiddenButton.Select();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonSelect();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if submit coroutine is running keeps the button from being deselected too early
        if (startResumeButton && submitting) 
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

        //Ensure cursor gets locked when starting/resuming gameplay in WEBGL build
        if (startResumeButton)
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

    private void TextObjectsOff()
    {
        text.SetActive(false);
        textSelect.SetActive(false);
        textSubmit.SetActive(false);
    }

    private void HandleButtonSelect()
    {
        TextObjectsOff();
        textSelect.SetActive(true);
    }

    private void HandleButtonDeselect()
    {
        TextObjectsOff();
        text.SetActive(true);
    }

    private void HandleButtonSubmit()
    {
        TextObjectsOff();
        textSubmit.SetActive(true);
    }

    private IEnumerator ButtonSubmitCoroutine()
    {
        submitting = true;
        HandleButtonSubmit();

        yield return new WaitForSecondsRealtime(submitDelay);

        ButtonDeselect();

        onSubmit?.Invoke();
        submitting = false;
    }

}
