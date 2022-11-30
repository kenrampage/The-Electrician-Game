using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// Manager class for printing dialogue, animating the window in/out, playing audio and visual effects for the walkie talkie
// Receives input from SODialogueBoxRemote scriptable object
public class DialogueBoxManager : MonoBehaviour
{
    [Header("Text Objects")]
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _messageText;

    [Header("Audio")]
    [SerializeField] private FMODPlay _audioSource;

    [Header("Scriptable Objects")]
    [SerializeField] private SODialogueBoxRemote _remote;
    [SerializeField] private SOTriggerInputActionMapChange _inputActionMapChangeTrigger;

    [Header("References")]
    [SerializeField] private AnimationHelper _animHelper;
    [SerializeField] private GameObject _buttonPrompts;
    [SerializeField] private DialogueWalkieEffectManager _walkieEffectManager;

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

        // Stops current text printing
        StopAllCoroutines();

        // Turns off any button prompts currently active
        _buttonPrompts.SetActive(false);

        // Checks if the dialogue data requires input and switches action map accordingly
        if (_remote.Data.CheckifInputRequired())
        {
            _inputActionMapChangeTrigger.SwitchToDialogueInput();
            print("Switched to Dialogue Action Map");
        }

        // Sets the effect type for the walkie talkie graphic then ends any currently playing effects
        _walkieEffectManager.SetEffectType(_remote.Data.GetWalkieEffectType());
        _walkieEffectManager.EndEffect();

        // Start Dialogue
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
            if (_remote.Data.CheckifInputRequired())
            {
                _inputActionMapChangeTrigger.SwitchToPlayerInput();
            }
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
        _walkieEffectManager.StartEffect();
        _audioSource.StartEvent();

        foreach (char character in _remote.Data.GetMessageText())
        {
            _messageText.text += character;

            yield return new WaitForSeconds(_remote.Data.GetCharInterval());
        }

        _audioSource.StopEventNoFadeout();
        _walkieEffectManager.EndEffect();

        yield return new WaitForSeconds(_remote.Data.GetPageDelay());

        _isPrintingText = false;

        if (_remote.Data.CheckifInputRequired())
        {
            _buttonPrompts.SetActive(true);
        }
        else
        {
            HandleDialogueNext();
        }

    }

    private void SetFMODEvent()
    {
        _audioSource.SetFMODEvent(_remote.Data.GetFmodEvent());
    }
}
