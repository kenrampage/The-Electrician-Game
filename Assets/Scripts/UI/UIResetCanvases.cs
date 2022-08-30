using UnityEngine;

public class UIResetCanvases : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _defaultObject;
    [SerializeField] private GameObject[] _objects;

    public void ResetObjects()
    {
        foreach (var item in _objects)
        {
            item.SetActive(false);
        }

        _defaultObject.SetActive(true);
    }
}
