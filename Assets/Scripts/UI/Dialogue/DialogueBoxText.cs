using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBoxText : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _messageText;

    [Header("Audio")]
    [SerializeField] private FMODPlay _audioSource;

    [Header("References")]
    [SerializeField] private SODialogueBoxRemote _remote;
    [SerializeField] private AnimationHelper _animHelper;
    [SerializeField] private GameObject _buttonPrompts;
    [SerializeField] private DialogueWalkieVisual _walkieVisual;

    [Header("Settings")]
    [SerializeField] private float _buttonPromptDelay;

    private bool _isPrintingText = false;

    private void Awake()
    {
        _remote.EventDialogueOn.AddListener(HandleDialogueOn);
        _remote.EventDialogueOff.AddListener(HandleDialogueOff);
        _remote.EventDialogueStart.AddListener(HandleDialogueStart);
        _remote.EventDialogueNext.AddListener(HandleDialogueNext);
        _remote.EventDialoguePrev.AddListener(HandleDialoguePrev);
    }

    private void HandleDialogueOn()
    {
        // Get FMOD event from dialogue data and set it into the audio source
        SetFMODEvent();

        // populate name text
        _nameText.text = _remote.Data.GetNameText();

        // Set name text color
        _nameText.color = _remote.Data.GetNameColor();

        // Set Font
        _nameText.font = _remote.Data.GetFontAsset();

        // Animate panel in
        _animHelper.PlayAnimAtIndex(0);

        // Start Dialogue
        StopAllCoroutines();
        _buttonPrompts.SetActive(false);

        _walkieVisual.SetEffectType(_remote.Data.GetWalkieEffectType());
        _walkieVisual.EndEffect();

        HandleDialogueStart();
    }

    private void HandleDialogueOff()
    {
        // Animate Panel Out
        _animHelper.PlayAnimAtIndex(1);

    }

    private void HandleDialogueStart()
    {
        // Populate line[0] message text
        _messageText.font = _remote.Data.GetFontAsset();

        StartCoroutine(PrintDialogueCoroutine());
    }

    private void HandleDialogueNext()
    {
        if (_isPrintingText)
        {
            return;
        }

        StopAllCoroutines();
        _buttonPrompts.SetActive(false);

        if (_remote.Data.CheckIfLastMessage())
        {
            HandleDialogueOff();
        }
        else
        {
            _remote.Data.IncrementIndex();
            StartCoroutine(PrintDialogueCoroutine());
        }
    }

    private void HandleDialoguePrev()
    {
        if (_isPrintingText)
        {
            return;
        }

        if (!_remote.Data.CheckIfFirstMessage())
        {
            StopAllCoroutines();
            _buttonPrompts.SetActive(false);
            _remote.Data.DecrementIndex();
            StartCoroutine(PrintDialogueCoroutine());
        }

    }

    private IEnumerator PrintDialogueCoroutine()
    {
        _messageText.text = string.Empty;
        _isPrintingText = true;
        _walkieVisual.StartEffect();
        _audioSource.StartEvent();

        foreach (char character in _remote.Data.GetMessageText())
        {
            _messageText.text += character;

            yield return new WaitForSeconds(_remote.Data.GetCharInterval());
        }

        _audioSource.StopEventNoFadeout();
        _walkieVisual.EndEffect();

        yield return new WaitForSeconds(_buttonPromptDelay);
        _buttonPrompts.SetActive(true);
        
        _isPrintingText = false;

    }

    private void SetFMODEvent()
    {
        _audioSource.SetFMODEvent(_remote.Data.GetFmodEvent());
    }
}
