using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles transitioning from current scene to target scene, reloading current scene, or going back to start menu with a delay
namespace RampageUtils.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _mainMenuSceneName = "MainMenu";
        [SerializeField] private string _targetSceneName;
        [SerializeField] private float _loadDelay;

        private Scene _activeScene;

        // private void GetActiveScene()
        // {
        //     _activeScene = SceneManager.GetActiveScene();
        // }

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
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
