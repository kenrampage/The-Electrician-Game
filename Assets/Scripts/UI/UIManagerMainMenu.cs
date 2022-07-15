using UnityEngine;

namespace RampageUtils.UI
{   
    // Manager for easier swapping between UI canvases on in the main menu scene
    public class UIManagerMainMenu : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _startUI;
        [SerializeField] private GameObject _settingsUI;

        public void StartUIOn()
        {
            AllUIOff();
            _startUI.SetActive(true);
        }

        public void SettingsUIOn()
        {
            AllUIOff();
            _settingsUI.SetActive(true);
        }

        private void AllUIOff()
        {
            _startUI.SetActive(false);
            _settingsUI.SetActive(false);
        }

    }
}
