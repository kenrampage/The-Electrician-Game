using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RampageUtils.SceneManagement
{
    // Handles transitioning from current scene to target scene, reloading current scene, or going back to start menu with a delay
    public class SceneChanger : MonoBehaviour
    {
        private Scene _activeScene;

        [Header("Settings")]
        [SerializeField] private string _mainMenuSceneName = "LoadingScene_MainMenu";
        [SerializeField] private string _targetSceneName;
        [SerializeField] private float _loadDelay;

        private void OnEnable()
        {
            GetActiveScene();
        }

        private void GetActiveScene()
        {
            _activeScene = SceneManager.GetActiveScene();
        }

        public void ReloadCurrentScene()
        {
            StartCoroutine(ReloadCurrentSceneCoroutine());
        }

        public void LoadMainMenu()
        {
            StartCoroutine(LoadMainMenuCoroutine());
        }

        public void LoadTargetScene()
        {
            StartCoroutine(LoadTargetSceneCoroutine());
        }

        public void SetTargetScene(string name)
        {
            _targetSceneName = name;
        }

        #region Coroutines
        private IEnumerator ReloadCurrentSceneCoroutine()
        {
            yield return new WaitForSecondsRealtime(_loadDelay);
            SceneManager.LoadScene(_activeScene.name, LoadSceneMode.Single);
        }

        private IEnumerator LoadMainMenuCoroutine()
        {
            yield return new WaitForSecondsRealtime(_loadDelay);
            SceneManager.LoadScene(_mainMenuSceneName, LoadSceneMode.Single);
        }

        private IEnumerator LoadTargetSceneCoroutine()
        {
            yield return new WaitForSecondsRealtime(_loadDelay);
            SceneManager.LoadScene(_targetSceneName, LoadSceneMode.Single);
        }
        #endregion
    }
}
