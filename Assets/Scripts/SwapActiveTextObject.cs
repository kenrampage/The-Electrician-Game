using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapActiveTextObject : MonoBehaviour
{
    [SerializeField] private GameObject plainText;
    [SerializeField] private GameObject selectText;
    [SerializeField] private GameObject submitText;

    private void AllTextOff()
    {
        plainText.SetActive(false);
        submitText.SetActive(false);
        selectText.SetActive(false);
    }

    public void TextPlain()
    {
        AllTextOff();
        plainText.SetActive(true);
    }

    public void TextSubmit()
    {
        AllTextOff();
        submitText.SetActive(true);
    }

    public void TextSelect()
    {
        AllTextOff();
        selectText.SetActive(true);
    }
}
