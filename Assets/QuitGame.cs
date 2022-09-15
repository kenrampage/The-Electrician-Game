using System.Collections;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _delay;

    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        yield return new WaitForSecondsRealtime(_delay);
        Application.Quit();
    }

}
