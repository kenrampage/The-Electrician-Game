using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGame : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject pauseUI;

    public void StartUIOn()
    {
        AllUIOff();
        startUI.SetActive(true);
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
    }

    public void PauseUIOn()
    {
        AllUIOff();
        pauseUI.SetActive(true);
    }

    public void AllUIOff()
    {
        startUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        pauseUI.SetActive(false);
    }
}
