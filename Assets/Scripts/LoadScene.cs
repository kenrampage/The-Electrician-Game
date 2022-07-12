using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float delay;

    private IEnumerator LoadWithDelay()
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void Load()
    {
        StartCoroutine(LoadWithDelay());
    }
}
