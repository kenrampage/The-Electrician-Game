using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGame : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject pauseUI;

    private Anim_ClipboardVert startUIAnim;
    private Anim_ClipboardVert gameUIAnim;
    private Anim_ClipboardVert endUIAnim;
    private Anim_ClipboardVert pauseUIAnim;

    private void Awake()
    {
        GetAnimReferences();
    }

    private void GetAnimReferences()
    {
        startUIAnim = startUI.GetComponent<Anim_ClipboardVert>();
        gameUIAnim = gameUI.GetComponent<Anim_ClipboardVert>();
        endUIAnim = endUI.GetComponent<Anim_ClipboardVert>();
        pauseUIAnim = pauseUI.GetComponent<Anim_ClipboardVert>();
    }

    public void StartUIOn()
    {
        AllUIOff();
        startUI.SetActive(true);
        startUIAnim.ClipboardIn();
    }

    public void GameUIOn()
    {
        AllUIOff();
        gameUI.SetActive(true);
    }

    public void EndUIOn()
    {
        AllUIOff();
        endUI.SetActive(true);
        endUIAnim.ClipboardIn();
    }

    public void PauseUIOn()
    {
        AllUIOff();
        pauseUI.SetActive(true);
        pauseUIAnim.ClipboardIn();
    }

    public void StartUIOff()
    {
        startUIAnim.ClipboardOut();
    }

    public void PauseUIOff()
    {
        pauseUIAnim.ClipboardOut();
    }

    public void EndUIOff()
    {
        endUIAnim.ClipboardOut();
    }

    private void AllUIOff()
    {
        startUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        pauseUI.SetActive(false);
    }


}
