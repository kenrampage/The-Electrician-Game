using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGame : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject pauseUI;

    private AnimationHelper startUIAnim;
    private AnimationHelper gameUIAnim;
    private AnimationHelper endUIAnim;
    private AnimationHelper pauseUIAnim;

    private void Awake()
    {
        GetAnimReferences();
    }

    private void GetAnimReferences()
    {
        startUIAnim = startUI.GetComponent<AnimationHelper>();
        gameUIAnim = gameUI.GetComponent<AnimationHelper>();
        endUIAnim = endUI.GetComponent<AnimationHelper>();
        pauseUIAnim = pauseUI.GetComponent<AnimationHelper>();
    }

    public void StartUIOn()
    {
        AllUIOff();
        startUI.SetActive(true);
        startUIAnim.PlayAnimAtIndex(0);
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
        endUIAnim.PlayAnimAtIndex(0);
    }

    public void PauseUIOn()
    {
        AllUIOff();
        pauseUI.SetActive(true);
        pauseUIAnim.PlayAnimAtIndex(0);
    }

    public void StartUIOff()
    {
        startUIAnim.PlayAnimAtIndex(1);
    }

    public void PauseUIOff()
    {
        pauseUIAnim.PlayAnimAtIndex(1);
    }

    public void EndUIOff()
    {
        endUIAnim.PlayAnimAtIndex(1);
    }

    private void AllUIOff()
    {
        startUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        pauseUI.SetActive(false);
    }


}
