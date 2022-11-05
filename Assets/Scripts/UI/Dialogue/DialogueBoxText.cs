using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBoxText : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SODialogueBoxRemote _remote;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _messageText;

    private bool _isWritingText;

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
        // Set size of text panel?

        // populate name text
        _nameText.text = _remote.Data.GetNameText();

        // Set name text color
        _nameText.color = _remote.Data.GetNameColor();

        // Set Font
        _nameText.font = _remote.Data.GetFontAsset();
        

        // Animate panel in

        HandleDialogueStart();
    }

    private void HandleDialogueOff()
    {
        // Animate Panel Out
        // Clear name text
        // Clear message text
    }

    private void HandleDialogueStart()
    {
        // Populate line[0] message text
        _messageText.font = _remote.Data.GetFontAsset();
        _messageText.text = _remote.Data.GetMessageText();

        // set iswritingtext to true until entire line is loaded then set to false
    }

    private void HandleDialogueNext()
    {
        // if writingtext is false, increment dialogue index and call handledialoguestart
        _remote.Data.IncrementIndex();
        _messageText.text = _remote.Data.GetMessageText();

    }

    private void HandleDialoguePrev()
    {
        // if writingtext is false, increment dialogue index and call handledialoguestart
        _remote.Data.DecrementIndex();
        _messageText.text = _remote.Data.GetMessageText();

    }
}
