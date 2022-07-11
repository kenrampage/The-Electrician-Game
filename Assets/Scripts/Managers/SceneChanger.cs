using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Scene currentScene;
    [SerializeField] private string targetScene;
    [SerializeField] private float loadDelay;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
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

    public IEnumerator ReloadCurrentSceneCoroutine()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
    }

    public IEnumerator LoadMainMenuCoroutine()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene("LoadingScene_StartMenu", LoadSceneMode.Single);
    }

    public IEnumerator LoadTargetSceneCoroutine()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }
}
