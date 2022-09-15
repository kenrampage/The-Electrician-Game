using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// Exists in loading scene to load next scenes and relevant fmod banks
namespace RampageUtils.SceneManagement
{
    public class LoadingSceneHandler : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _loadDelay;
        [SerializeField] private bool _isLoggingOn = true;
        [SerializeField] [FMODUnity.BankRef] private List<string> _fmodBanks = new List<string>();
        [SerializeField] private List<string> _scenesToLoad;

        private List<AsyncOperation> _loadOperations = new List<AsyncOperation>();

        private bool _loadingStarted = false;
        private bool _loadOnStart = false;

        public void Start()
        {
            // // Due to an FMOD bug, loading must be initiated by user input for WEBGL builds
#if !UNITY_WEBGL

            _loadOnStart = true;
#endif
            if (_loadOnStart)
            {
                StartCoroutine(LoadScenesAsync());
            }
        }

        private IEnumerator LoadScenesAsync()
        {
            for (int i = 0; i < _scenesToLoad.Count; i++)
            {
                _loadOperations.Add(SceneManager.LoadSceneAsync(_scenesToLoad[i], LoadSceneMode.Additive));
                _loadOperations[i].allowSceneActivation = false;
            }

            foreach (var bank in _fmodBanks)
            {
                FMODUnity.RuntimeManager.LoadBank(bank, true);
            }

            // Keep yielding the co-routine until all the bank loading is done
            // (for platforms with asynchronous bank loading)
            while (!FMODUnity.RuntimeManager.HaveAllBanksLoaded)
            {
                yield return null;
            }

            Log("All FMOD _fmodBanks have loaded");
            // Keep yielding the co-routine until all the sample data loading is done
            while (FMODUnity.RuntimeManager.AnySampleDataLoading())
            {
                yield return null;
            }

            Log("All FMOD Samples have loaded");

            yield return new WaitForSeconds(_loadDelay);
            // Allow the scene to be activated. This means that any OnActivated() or Start()
            // methods will be guaranteed that all FMOD Studio loading will be completed and
            // there will be no delay in starting events

            foreach (var async in _loadOperations)
            {
                async.allowSceneActivation = true;

                while (!async.isDone)
                {
                    yield return null;
                }
            }

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());



        }

        private void Log(string text)
        {
            if (_isLoggingOn)
            {
                Debug.Log(text);
            }
        }

        public void StartLoad()
        {
            if (!_loadingStarted)
            {
                StartCoroutine(LoadScenesAsync());
                _loadingStarted = true;
            }
            else
            {
                return;
            }

        }
    }
}
