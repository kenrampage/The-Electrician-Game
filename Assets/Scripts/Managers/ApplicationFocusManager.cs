using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFocusManager : MonoBehaviour
{
    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
        {
            FMODUnity.RuntimeManager.CoreSystem.mixerResume();
            Time.timeScale = 1;
        }
        else
        {
            FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
            Time.timeScale = 0;
        }
    }
}
