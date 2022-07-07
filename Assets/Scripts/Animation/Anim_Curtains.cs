using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Curtains : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private bool startOpen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (startOpen)
        {
            CurtainsOpen();
        }
        else
        {
            CurtainsClose();
        }
    }

    [ContextMenu("Open Curtains")]
    public void CurtainsOpen()
    {
        anim.SetBool("isOpen", true);
    }

    [ContextMenu("Close Curtains")]
    public void CurtainsClose()
    {
        anim.SetBool("isOpen", false);
    }
}
