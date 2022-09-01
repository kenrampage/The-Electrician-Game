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
        [SerializeField] private bool _isLoggingOn = true;
        [SerializeField] [FMODUnity.BankRef] private List<string> _fmodBanks = new List<string>();
        [SerializeField] private List<string> _scenesToLoad;
        // [SerializeField] private List<string> _scenesToUnload;

        private List<AsyncOperation> _loadOperations = new List<AsyncOperation>();

        // [SerializeField] private string _sceneToActivate;

        public void Start()
        {
            // StartCoroutine(LoadGameAsync());
            StartCoroutine(LoadScenesAsync());
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

            // foreach (var scene in _scenesToUnload)
            // {
            //     SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(scene));
            // }

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            // if (_sceneToActivate != string.Empty)
            // {
            //     SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneToActivate));
            // }
        }

        // IEnumerator LoadGameAsync()
        // {
        //     // Start an asynchronous operation to load the scene
        //     AsyncOperation async = SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);

        //     // Don't allow the scene to start until all Studio _fmodBanks have finished loading
        //     async.allowSceneActivation = false;

        //     // Iterate all the Studio _fmodBanks and start them loading in the background
        //     // including the audio sample data
        //     foreach (var bank in _fmodBanks)
        //     {
        //         FMODUnity.RuntimeManager.LoadBank(bank, true);
        //     }

        //     // Keep yielding the co-routine until all the bank loading is done
        //     // (for platforms with asynchronous bank loading)
        //     while (!FMODUnity.RuntimeManager.HaveAllBanksLoaded)
        //     {
        //         yield return null;
        //     }

        //     Log("All FMOD _fmodBanks have loaded");
        //     // Keep yielding the co-routine until all the sample data loading is done
        //     while (FMODUnity.RuntimeManager.AnySampleDataLoading())
        //     {
        //         yield return null;
        //     }

        //     Log("All FMOD Samples have loaded");
        //     // Allow the scene to be activated. This means that any OnActivated() or Start()
        //     // methods will be guaranteed that all FMOD Studio loading will be completed and
        //     // there will be no delay in starting events
        //     async.allowSceneActivation = true;

        //     // Keep yielding the co-routine until scene loading and activation is done.
        //     while (!async.isDone)
        //     {
        //         yield return null;
        //     }
        // }

        private void Log(string text)
        {
            if (_isLoggingOn)
            {
                Debug.Log(text);
            }
        }
    }
}
