using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_ClipboardVert : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private bool startIn;

    private void Awake()
    {
        if (startIn)
        {
            ClipboardIn();
        }
        else
        {
            ClipboardOut();
        }
    }

    [ContextMenu("Clipboard In")]
    public void ClipboardIn()
    {
        anim.SetBool("isIn", true);
    }

    [ContextMenu("Clipboard Out")]
    public void ClipboardOut()
    {
        anim.SetBool("isIn", false);
    }
}
