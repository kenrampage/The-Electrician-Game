using UnityEngine;

public class UIManagerMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject settingsUI;

    public void StartUIOn()
    {
        AllUIOff();
        startUI.SetActive(true);
    }

    public void SettingsUIOn()
    {
        AllUIOff();
        settingsUI.SetActive(true);
    }


    private void AllUIOff()
    {
        startUI.SetActive(false);
        settingsUI.SetActive(false);
    }

}
