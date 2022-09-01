using UnityEngine;

// For resetting the variables in any included Scriptable Objects
public class ScriptableObjectResetter : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private SOSessionData _sessionData;

    private void Awake()
    {
        ResetScriptables();
    }

    private void ResetScriptables()
    {
        _sessionData.Reset();
    }
}
